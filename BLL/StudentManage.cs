namespace BLL;
using BOL;
using DAL;

public class StudentManage{
    public static StudentManage instance=null;

    public static StudentManage GetManage(){
        if(instance==null){
            instance=new StudentManage();
        }
        return instance;
    }
    public List<Student1> GetAll(){
        StudentIoManage sim = new StudentIoManage();
         Console.WriteLine("In BLL");
        return sim.GetAll();
    }
    public List<Department> GetAlldep(){
         StudentIoManage sim = new StudentIoManage();
        return sim.GetAlldep();
    }

    public bool Addstud(int sid,string sname,string dname){
         StudentIoManage sim = new StudentIoManage();
         return sim.Addstud(sid,sname,dname);
    }
    public bool delete(int studid){
        StudentIoManage sim = new StudentIoManage();
        return sim.delete(studid);
    }
    public bool edit(int studid,string sname ,string dname){
        StudentIoManage sim =  new StudentIoManage();
        return sim.edit(studid,sname,dname);
    }
}