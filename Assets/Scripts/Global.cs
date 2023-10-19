
public class Global
{


    //싱글턴 패턴을 적용합니다.
    ////////////////////////////////////////////////////////
    public static Global Instance => I;

    private static Global I = new Global();
    private Global() { }
    ////////////////////////////////////////////////////////

    

}