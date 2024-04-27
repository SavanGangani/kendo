using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvc.Models;
using Npgsql;

namespace mvc.Repo
{
    public class HomeRepository:CommonRepository
    {
        public  List<tblSRS> GetAllStudent(){
            List<tblSRS> students = new List<tblSRS>();
            try
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT c_sid, c_name, c_gender, c_photo, c_area, c_admission_date, c_hobby FROM t_srs ORDER BY c_sid", conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while(reader.Read()){
                            students.Add(new tblSRS{
                                c_sid = reader.GetInt32(0),
                                c_name = reader.GetString(1),
                                c_gender = reader.GetString(2),
                                c_photo = reader.GetString(3),
                                c_area = reader.GetString(4),
                                c_admission_date = reader.GetDateTime(5),
                                c_hobby = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally{
                conn.Close();
            }
            return students;
        }

        public void EditStudent(tblSRS student){
            try
            {
                conn.Open();
                using (var command = new NpgsqlCommand("UPDATE t_srs SET c_name = @name, c_gender=@gender, c_photo=@img, c_area=@area, c_admission_date=@admisstionate, c_hobby=@hobby WHERE c_sid = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", student.c_sid);
                    command.Parameters.AddWithValue("@name", student.c_name);
                    command.Parameters.AddWithValue("@gender", student.c_gender);
                    command.Parameters.AddWithValue("@img", student.c_photo);
                    command.Parameters.AddWithValue("@area", student.c_area);
                    command.Parameters.AddWithValue("@admisstionate", student.c_admission_date);
                    command.Parameters.AddWithValue("@hobby", student.c_hobby);
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }finally{
                conn.Close();
            }
        }

        public void AddStudent(tblSRS student){
            try
            {
             conn.Open();   
             using (var command = new NpgsqlCommand("INSERT INTO t_srs (c_name, c_gender, c_photo, c_area, c_admission_date, c_hobby) VALUES (@name, @gender, @photo, @area, @admission_date, @hobby)", conn))
             {
                command.Parameters.AddWithValue("@name", student.c_name);
                command.Parameters.AddWithValue("@gender", student.c_gender);
                command.Parameters.AddWithValue("@photo", student.c_photo);
                command.Parameters.AddWithValue("@area", student.c_area);
                command.Parameters.AddWithValue("@admission_date", student.c_admission_date);
                command.Parameters.AddWithValue("@hobby", student.c_hobby);
                command.ExecuteNonQuery();  
             }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }finally{
                conn.Close();
            }
        }

        public void DeleteStudent(int id){
            try
            {
                conn.Open();
                using (var command = new NpgsqlCommand("DELETE FROM t_srs WHERE c_sid = @id", conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}