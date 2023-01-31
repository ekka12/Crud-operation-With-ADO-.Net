namespace DAL;

using BOL;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

public class StudentIoManage{
    public  List<Student1> GetAll(){
        List<Student1>slist = new List<Student1>();
        string url =@"server=192.168.10.109;user=dac41;password=welcome;database=dac41";
        MySqlConnection con = new MySqlConnection(url);
        string query = "select * from student1 order by studid";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){

            int id = int.Parse(reader["studid"].ToString());
            string name = reader["studname"].ToString();
            int did = int.Parse(reader[2].ToString());
            Student1 s1 = new Student1{StudId=id,StudName=name,DeptId=did};
            slist.Add(s1);
        }
        con.Close();
         Console.WriteLine("In DAL");
        return slist;
    }

    public List<Department> GetAlldep(){
        List<Department>slist = new List<Department>();
        string url =@"server=192.168.10.109;user=dac41;password=welcome;database=dac41";
        MySqlConnection con = new MySqlConnection(url);
        string query = "select * from Department1 ";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        MySqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){

            int id = int.Parse(reader["depid"].ToString());
            string name = reader["deptname"].ToString();
           
            Department d1 = new Department{DepId=id,DepName=name};
          slist.Add(d1);
        }
        con.Close();

        return slist;
    }

    public bool Addstud(int sid,string sname,string dname){
        bool status =false;

        string url = @"server=192.168.10.109;user=dac41;password=welcome;database=dac41";
        MySqlConnection con = new MySqlConnection(url);
        string query= " insert into Student1 values ("+sid+",'"+sname+"',(select depid from department1 where deptname='"+dname+"'))";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        status= true;
        con.Close();

        return status;
    }

    public bool delete(int studid){
        bool status = false;

        string url = @"server=192.168.10.109;user=dac41;password=welcome;database=dac41";
        MySqlConnection con = new MySqlConnection(url);
        string query = "delete from student1 where studid = "+studid;
        MySqlCommand cmd =new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        status = true;
        con.Close();

        return status;
    }

    public bool edit(int studid,string sname, string dname){
        bool  status = false;
        string url =@"server=192.168.10.109;user=dac41;password=welcome;database=dac41";
        MySqlConnection con = new MySqlConnection(url);
        string query = " update student1 set studname='"+sname+"',depaid=(select depid from department1 where deptname='"+dname+"') where studid="+studid;
        MySqlCommand cmd =new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText=query;
        con.Open();
        cmd.ExecuteNonQuery();
        status=true;
        con.Close();

        return status;
    }

}