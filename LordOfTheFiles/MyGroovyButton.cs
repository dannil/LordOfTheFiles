using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace LordOfTheFiles
{
    /// <summary>
    /// En egen klass för mina knappar jag har använt
    /// </summary>
    class MyGroovyButton: Button
    {
        /// <summary>
        /// Sätter valet av bilder på knappen när musen går över knappen eller när den lämnar knappen
        /// </summary>
        public MyGroovyButton(): base()
        {
            this.Image = ((System.Drawing.Image)(Properties.Resources.NormalButtom));
            this.MouseEnter += new EventHandler(btn_ShowRecept_MouseEnter);
            this.MouseLeave += new EventHandler(btn_ShowRecept_MouseLeave);
        }

        /// <summary>
        /// Bild valet av när musen lämnar knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_ShowRecept_MouseLeave(object sender, EventArgs e)
        {
            this.Image = ((System.Drawing.Image)(Properties.Resources.NormalButtom));
        }

        /// <summary>
        /// Bild valet av när musen går över knappen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btn_ShowRecept_MouseEnter(object sender, EventArgs e)
        {
            this.Image = ((System.Drawing.Image)(Properties.Resources.HighligtedButtom));
        }

    }
}
