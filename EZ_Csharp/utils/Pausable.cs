namespace EZ_Csharp.utils;

public interface IPausable
{
    bool IsAwake { get;  set; }
    
    void PauseAll();

    void ResumeAll();
}