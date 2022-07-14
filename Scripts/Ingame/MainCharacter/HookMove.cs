using System;
using Ingame.HookableItem;
using Shop;
using Unity.Mathematics;
using UnityEngine;
using UserData;
using Random = UnityEngine.Random;


namespace Ingame.MainCharacter
{
    /// <summary>
    /// Move Hook , Physics 
    /// </summary>
    public class HookMove : MonoBehaviour
    {
        /// <summary>
        /// State Machine
        /// </summary>
        private enum HookState
        {
            Rotation,
            Shoot,
            Rewind
        }

        #region Varriable

        [Header("Ref")] [SerializeField] GameObject fxBoomPrefab;
        [SerializeField] Animator animator;
        [SerializeField] private Transform pointSetParent;

        [SerializeField] private GameObject floatingTextPrefab;

        [Header("Config")] [SerializeField] int slowDown;
        [SerializeField] float rotateSpeed = 2;
        [SerializeField] float speedDrag = 20;

        #endregion //public

        #region Private Variable

        private HookState _hookState = HookState.Rotation;

        private Transform _item;
        private float _angle;
        private int _moneyItem;
        private Vector3 _origin;
        private bool _flagItem; // only one item

        private static readonly int Bom = Animator.StringToHash(("bom"));
        private static readonly int Hard = Animator.StringToHash("hard");

        #endregion //variable

        public event Action OnInventoryChanged;
        
        #region PRIVATE Method

        private void Awake()
        {
            _origin = transform.position;
        }

        #region Physic

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_flagItem) return;
            _flagItem = true;

            _item = col.transform;
            _hookState = HookState.Rewind;
            slowDown = _item.GetComponent<Items>().slowDown;
            _moneyItem = _item.GetComponent<Items>().moneyItem;

            IfCollider2D(col);
            _item.SetParent(transform);
            col.transform.position = pointSetParent.transform.position;
        }

        private void IfCollider2D(Collider2D col)
        {
            if (UserInventory.Instance.x3PrinceRock)
            {
                if (col.CompareTag("RockTag"))
                {
                    _moneyItem *= 3;
                }
            }

            if (col.CompareTag("BagTag"))
            {
                int min = 100;
                int max = 1000;

                var money = Random.Range(min, max);
                if (UserInventory.Instance.x2ValueBag)
                {
                    money *= 2;
                }

                _moneyItem = money;
            }
        }

        #endregion

        private void Update()
        {
            RopeMove();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        /// <summary>
        /// Switch case State Machine
        /// </summary>
        private void RopeMove()
        {
            switch (_hookState)
            {
                case HookState.Rotation:
                    UpdateRotationState();
                    break;

                case HookState.Shoot:
                    UpdateShootState();
                    break;

                case HookState.Rewind:
                    UpdateRewindState();
                    break;
            }
        }

        private void UpdateRewindState()
        {
            ManagerAudio.Instance.AudioRewind();
            if (Input.GetKeyDown(KeyCode.UpArrow) && UserInventory.Instance.BoomInt() >= 1) // boom > 0
            {
                Debug.Log("boom");
                if (_item != null)
                {
                    DragWhenHaveBoom();
                }
            }

            if (slowDown >= 5)
            {
                // animation hard
                animator.SetBool(Hard, true);
            }

            if (UserInventory.Instance.quickPull)
            {
                transform.Translate(Vector3.up * (speedDrag * Time.deltaTime));
            }
            else
            {
                transform.Translate(Vector3.up * ((speedDrag - slowDown) * Time.deltaTime));
            }

            if (MathF.Floor(transform.position.x) == MathF.Floor(_origin.x) &&
                MathF.Floor(transform.position.y) == MathF.Floor(_origin.y))
            {
                if (_item != null)
                {
                    Drag();
                    animator.SetBool(Hard, false);
                }
                transform.position = _origin;
                _hookState = HookState.Rotation;
            }
        }

        private void UpdateShootState()
        {
            //audio
            ManagerAudio.Instance.AudioShoot();
            int max_X = 8;
            int max_y = -7;
            transform.Translate(Vector3.down * (speedDrag * Time.deltaTime));
            if (MathF.Abs(transform.position.x) > max_X || transform.position.y < max_y)
            {
                _hookState = HookState.Rewind;
            }
        }

        void UpdateRotationState()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown((KeyCode.DownArrow))) // drag
            {
                _hookState = HookState.Shoot;
            }

            int maxRotion = 70;
            int changeDirection = -1;

            _angle += rotateSpeed * Time.deltaTime;
            if (_angle > maxRotion || _angle < -maxRotion)
            {
                rotateSpeed *= changeDirection;
            }

            transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }
        // ReSharper disable Unity.PerformanceAnalysis
        private void DragWhenHaveBoom()
        {
            //audio
            ManagerAudio.Instance.AudioBoom();
        
            //boom animation 
            animator.SetTrigger(Bom);
            _flagItem = false;
            slowDown = 0;
            Destroy(_item.gameObject);
            UserInventory.Instance.BoomSubtract(1);

            UserInventory.Instance.checkBoom = true;
        
            Instantiate(fxBoomPrefab, _item.transform.position, quaternion.identity);
        }

        private void Drag()
        {
            Destroy(_item.gameObject);
            slowDown = 0;
            _flagItem = false;
        
            //UserInventory.Instance.currentMoney += _moneyItem;
            UserInventory.Instance.UpdateCurrenMoney(_moneyItem);
        
            //Show float text
            ShowMoneyFx(_moneyItem.ToString());
        
            Debug.Log("money" + _moneyItem);
        }

        /// <summary>
        /// Instantiate Obj text show money;
        /// </summary>
        /// <param name="text"></param>
        void ShowMoneyFx(string text)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }

        #endregion //private
    }
}