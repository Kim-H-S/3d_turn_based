using UnityEngine;
using UnityEngine.UI;

public enum EnemyAction { Idle, Attack, Defence }

public class Enemy : Character, ICombatable
{
    public EnemySO enemySO;
    public BattleStateMachine<Enemy> battleStateMachine;

    public EnemyAction CurAction { get; private set; }

    public Light focusedLight;
    [SerializeField] private UIEnemyAction uiEnemyAction;
    

    private void Awake()
    {
        hpBar = GetComponentInChildren<Slider>();

        battleStateMachine = new BattleStateMachine<Enemy>();
        battleStateMachine.owner = this;

        battleStateMachine.states = new State<Enemy>[System.Enum.GetValues(typeof(EnemyStates)).Length];
        battleStateMachine.states[(int)EnemyStates.Action] = new StrategyAction();
        battleStateMachine.states[(int)EnemyStates.SetStrategy] = new SetStrategy();
        battleStateMachine.states[(int)EnemyStates.Idle] = new EnemyIdle();

        curHP = enemySO.HP;

        CurAction = EnemyAction.Idle;

        battleStateMachine.ChangeState((int)EnemyStates.Idle);
    }

    public void SetCurAction(EnemyAction newAction)
    {
        CurAction = newAction;
        uiEnemyAction.Updated(CurAction);
    }

    public void ApplyAttack() {
        atk = enemySO.ATK;
    }

    public void ApplyDefend()
    {
        def = enemySO.DEF;
    }

    public void ResetStat()
    {
        atk = 0;
        def = 0;
    }

    public void ApplyDamage(float damage) {
        def -= damage;

        float dmg = def < 0 ? -def : 0;

        curHP -= dmg;
        ShowDamageUI(dmg);

        hpBar.value = GetCurrentHP();

        if (curHP <= 0) {
            gameObject.SetActive(false);
            BattleManager.Instance.KillEnemy();
        }
    }

    public void SetAnimWithAction() {

    }

    public float GetCurrentHP() {
        return curHP / enemySO.HP;
    }
}
