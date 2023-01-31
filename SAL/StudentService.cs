namespace SAL;
using BOL;
using BLL;

public class StudentService{
    public List<Student1> GetAll(){
        StudentManage sm = new StudentManage();
         Console.WriteLine("In Sal");
        return sm.GetAll();

    }
    public List<Department> GetAlldep(){
        StudentManage sm = new StudentManage();
        return sm.GetAlldep();

    }

    public bool Addstud(int sid,string sname,string dname){
        StudentManage sm = new StudentManage();
        return sm.Addstud(sid,sname,dname);
    }

    public bool delete(int studid){
        StudentManage sm=new StudentManage();
        return sm.delete(studid);
    }
    public bool edit(int studid,string sname ,string dname){
        StudentManage sm = new StudentManage();
        return sm.edit(studid,sname,dname);
    }
}