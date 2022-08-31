using System;
using System.Timers;

namespace _20220902
{
    internal class Program
    {
        //        條件如下:
        //1. 大樓共10層樓，2部電梯
        //2. 電梯只可容納5人
        //3. 每行經一層樓需耗時1秒
        //4. 每停一次處理接人放人需耗1秒
        //5. 每秒產生1個人按電梯，設定出現樓層與目標的樓層，樓層隨機
        //6. 若電梯剛到該樓層，馬上按電梯，電梯不停
        //7. 模擬放進40人次，該設計需消耗掉所有人數，並統計秒數
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //流程
            //1-1. 預設電梯兩臺都在一樓。
            //1-2. 預設兩臺電梯命令接為ElevatorOrder.Free。

            //2-1. 預先執行一次CreatePerson()，創建人物。
            //2-2. 之後用TotoalPeople()去判定人數是否未滿40人，若未滿則執行CreatePerson()，創建人物產生。
            //2-3. 如果判定人數符合則不執行。

            //3-1. 每一秒執行一次IsStop()判斷是否停留該樓層。
            //4-1. IsStop() == true 執行 ElevatorPassenger() 來去計算電梯內進出人數再加上現有人數是否過載，並回傳滯留該樓層人數。
            //4-2. IsStop() == false 令一台ElevatorOrder.Free至該樓程，並一樣引用ElevatorPassenger()。


        }


    }
}
    