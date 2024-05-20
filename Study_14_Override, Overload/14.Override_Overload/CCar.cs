using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _14.Override_Overload
{
    class CCar : CCycle
    {
        public Rectangle _rtSquare2;  // 몸통2

        /// <summary>
        /// 생성자 : 상속받은 CCycle의 생성자를 가져옴
        /// </summary>
        /// <param name="sName"></param>
        public CCar(string sName) : base(sName)
        {
            strName = sName;  // 클래스를 생성 할 때 이름을 가져와서 strName에 넣어 줌
            _Pen = new Pen(Color.Blue, 3);  // 펜에 대한 색상과 굵기를 설정

            _rtCircle1 = new Rectangle(60, 180, 90, 90);  // 바퀴1에 대한 위치 및 크기를 설정
            _rtCircle2 = new Rectangle(210, 180, 90, 90);  // 바퀴2에 대한 위치 및 크기를 설정
            _rtSquare1 = new Rectangle(90, 30, 180, 90);  // 몸통1에 대한 위치 및 크기를 설정
            _rtSquare2 = new Rectangle(30, 120, 300, 60);  // 몸통2에 대한 위치 및 크기를 설정
        }

        /// <summary>
        /// 외부에서 그림의 위치를 이동시키는 함수를 호출 (상속받은 함수 중 같은 함수가 있기 때문에 new로 생성)
        /// </summary>
        /// <param name="iMove"></param>
        public override void fMove(int iMove)
        {
            base.fMove(iMove);

            //fCircle1Move(iMove);
            //fCircle2Move(iMove);
            //fSquare1Move(iMove);

            fSquare2Move(iMove);
        }

        /// <summary>
        /// 몸통2의 위치를 가져와서 X 위치값을 이동 시키고 다시 바퀴1에 위치 정보를 넣어줌
        /// </summary>
        /// <param name="iMove"></param>
        protected void fSquare2Move(int iMove)
        {
            Point oPoint = _rtSquare2.Location;
            oPoint.X = oPoint.X + iMove;
            _rtSquare2.Location = oPoint;
        }

    }
}
