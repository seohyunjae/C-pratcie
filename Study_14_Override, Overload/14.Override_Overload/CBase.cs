using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Override_Overload
{
    /// <summary>
    /// 기본 클래스
    /// </summary>
    class CBase
    {
        public string strName;  // 이름
        protected Pen _Pen;     // 펜

        /// <summary>
        /// 생성자
        /// </summary>
        public CBase()
        {
            _Pen = new Pen(Color.Aqua);
        }
    }
}
