using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Acap = Autodesk.AutoCAD.ApplicationServices.Application;

namespace InitAndOpt
{
    public class OptimizeClass
    {
        [CommandMethod("ty_OptCommand")]
        public void OptCommand()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            string fileName = "C:\\Hello_tty.dll";// Hello_tty.dll程序集的文件名
            try
            {
                //ExtensionLoader.Load(fileName); // 载入Hello.dll程序集
                ExtensionLoader.Load(fileName);
                // 在命令行上显示信息，提示用户Hello.dll程序集已经被载入
                ed.WriteMessage("\n tty aCad msg> " + fileName + " 被载入，请输入ty_Hello 进行测试！");
            }
            catch (System.Exception ex) //補捉程式異常
            {
                ed.WriteMessage("\ntty aCad msg>" + ex.Message); //顯示異常信息
            }
            finally
            {
                ed.WriteMessage("\ntty aCad msg> Finally：程式執行完畢！");
            }
        }
        [CommandMethod("ty_ChangeColor")]
        public void ChangeColor()
        {
            //對單AutoCad，有多個不同工作檔案開啟
            Database db = HostApplicationServices.WorkingDatabase;
            //or Database db = Acap.DocumentManager.MdiActiveDocument.Database;
            //對單AutoCad，有多個不同工作檔案開啟，限當前工作檔
            Editor ed = Acap.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                ObjectId id = ed.GetEntity("\ntty aCad msg> 請選擇要改變顏色的 物件。").ObjectId;
                using (Transaction trans=db.TransactionManager.StartTransaction())
                {
                    Entity ent = (Entity)trans.GetObject(id, OpenMode.ForWrite);
                    ent.ColorIndex = 30; //給異常值(應<255)，測試用
                    trans.Commit();
                }
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex) //捕獲 autocad 異常
            {
                switch (ex.ErrorStatus)
                {
                    case ErrorStatus.InvalidIndex: //錯誤原因：顏色值
                        ed.WriteMessage("\ntty aCad msg> 輸入的顏色值有誤！");
                        break;
                    case ErrorStatus.InvalidObjectId: //錯誤原因：未選擇物件
                        ed.WriteMessage("\ntty aCad msg> 請選擇 物件！");
                        break;
                    default:  //其他異常
                        ed.WriteMessage(ex.ErrorStatus.ToString());
                        break;
                }
            }
        }
    }
}
