using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _20220902.Elevator.People;

namespace _20220902
{
    public class Elevator
    {
        //電梯狀態  Stop表示停在剛樓層 Up表正在向上 Down正在向下
        enum ElevatorStatus { Stop, Up, Down }
        //電梯執行中命令 Free 待機  Up 向上 Down 停止
        enum ElevatorOrder { Free, Up, Down }
        
        //電梯A目前樓層
        enum ElevatorAFloor { one , two , three ,fore , five }
        //電梯B目前樓層
        enum ElevatorBFloor { one , two , three ,fore , five }

        //電梯數量
        public const int _ElevatorNumber = 2;
        //電梯程載量
        public const int _ElevatorPeople = 5;
        //建築物層高
        public const int _BuidingFloor = 10;

        //電梯A、B樓層，預設都在一樓
        public int _ElevatorAFloor = 1;
        public int _ElevatorBFloor = 1;

        //電梯A現有人數
        public int ElevatorA;
        //電梯B現有人數
        public int ElevatorB;

        //紀錄進出人數，目前暫訂用Linq 的Count()做計算
        public List<int> _TotalPeople; 

        //設一欄位儲存
        public People _People;
        
        //每個人所出現地點及目標地
        public class People
        {
            public List<Person> PeopleNumber { get; set; }
            public class Person
            {
                public int ApperFloor { get; set; }
                public int DestinationFloor { get; set; }
            }

        }
        //函式

        #region -- 每秒隨機產生一人 --

        //產生一人，並賦予出現樓層及目的地，並加進_people
        public void CreatePerson()
        {
            var person = new Person();
            int apper = RandomNumber();
            person.ApperFloor = apper;
            int destination = RandomNumber();
            //出現樓層數及目的地樓層數不同
            for (int i = 1; i > 0; i++)
            {
                if (apper != destination)
                {
                    person.DestinationFloor = destination;
                    break;
                }
            }
            _People.PeopleNumber.Add(person);
        }

        //亂數產生1~10樓
        public int RandomNumber()
        {
            Random random = new Random();
            int flootRandom = random.Next(1, _BuidingFloor);
            return flootRandom;
        }
        #endregion

        //電梯乘客進出，判斷進出後該樓層是否有人滯留
        public int ElevatorPassenger(int InputPassenger, int OutputPassenger, int NowPassenger)
        {
            //需判斷 進、出人數相減 + 現有人數後 是否滿載(5人)
            //回傳int 0表示全部進出完畢 ，非 0 則表示該樓層被滯留之人數。
            var realNumber = OutputPassenger - InputPassenger;
            if ((NowPassenger + realNumber) <= _ElevatorPeople)
            {
                return 0;
            }
            else
            {
                var stayNumber = NowPassenger + realNumber - _ElevatorPeople;
                return stayNumber;
            }
        }

        //判別電梯是否停下來
        public bool IsStop()
        {
            //預設A先接收指令
            //將levatorOrder.Free依需求變更為Up或Down
            //ElevatorOrder指令上或下，除非沒有再往上之請求不然不會接受往下之請求，反之亦然。
            //電梯前往指定樓層每秒加一樓，並每秒持續判斷命令同項是否有正確請求。
            //使用
            //正確請求:不接受到該樓瞬間所產生之人員請求，當ElevatorStatus.Stop 時該樓層人數原本從 0 -> 1，表示若電梯剛到該樓層，馬上按電梯，默認false，不執行ElevatorPassenger()

            //true 代表停留 ，false 不停留
            return true;
        }

        public void TotoalPeople()
        {
            //用linq 去計算 _TotalPeople
            //如果_TotalPeople!= 40 則執行CreatePerson()
            //_TotalPeople == 40 停止執行
        }
    }
}
