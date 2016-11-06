using AopLog.UnityAop;

namespace Sample
{
    public interface IMan
    {
        [Logger]
        void Say(string words);

        [Logger(Order=1)]
        [ExceptionLogger(Order=2)]
        void Run();
    }
}
