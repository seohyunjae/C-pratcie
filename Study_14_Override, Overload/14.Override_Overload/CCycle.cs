using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _14.Override_Overload
{
    class CCycle : COneCycle
    {
        public Rectangle _rtCircle2;  // 바퀴2

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="sName"></param>
        public CCycle(string sName) : base(sName)
        {
            strName = sName;  // 클래스를 생성 할 때 이름을 가져와서 strName에 넣어 줌
            _Pen = new Pen(Color.Black, 3);  // 펜에 대한 색상과 굵기를 설정

            _rtCircle1 = new Rectangle(30, 150, 120, 120);  // 바퀴1에 대한 위치 및 크기를 설정
            _rtCircle2 = new Rectangle(210, 150, 120, 120);  // 바퀴2에 대한 위치 및 크기를 설정
            _rtSquare1 = new Rectangle(60, 90, 240, 60);  // 몸통1에 대한 위치 및 크기를 설정
        }
        
        /// <summary>
        /// 외부에서 그림의 위치를 이동시키는 함수를 호출
        /// </summary>
        /// <param name="iMove"></param>
        public override void fMove(int iMove)
        {
            base.fMove(iMove);

            fCircle2Move(iMove);
        }

        /// <summary>
        /// 바퀴2의 위치를 가져와서 X 위치값을 이동 시키고 다시 바퀴1에 위치 정보를 넣어줌
        /// </summary>
        /// <param name="iMove"></param>
        protected void fCircle2Move(int iMove)
        {
            Point oPoint = _rtCircle2.Location;
            oPoint.X = oPoint.X + iMove;
            _rtCircle2.Location = oPoint;
        }
        
    }
}
