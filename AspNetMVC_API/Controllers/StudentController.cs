using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AspNetMVC_BLL.Repository;
using AspNetMVC_API_Entity.Models;
using AspNetMVC_API.Models.ViewModels;

namespace AspNetMVC_API.Controllers
{
    public class StudentController : ApiController
    {
        // GLOBAL ALAN
        StudentRepo myStudentRepo = new StudentRepo();
        public ResponseData GetAll()
        {
            try
            {
                var list = myStudentRepo.GetAll().Select(x=>
                new
                {
                    x.Id,
                    x.Name,
                    x.Surname,
                    x.RegisterDate
                }
                ).ToList();

                if (list!=null)
                {
                    if (list.Count==0)
                    {
                        return new ResponseData()
                        {
                            Success = true,
                            Message = "Veritabanında kayıtlı bir öğrenci bulunmamaktadır.",
                            Data = list,

                        };
                    }
                    return new ResponseData()
                    {
                        Success = true,
                        Message = "Tüm öğrenciler başarıyla gönderildi.",
                        Data = list,

                    };
                }
                else
                {
                    return new ResponseData()
                    {
                        Success = false,
                        Message = "Tüm öğrenciler getirilirken bir hata oluştu!"
                    };
                }
            }
            catch (Exception ex)
            {

                return new ResponseData()
                {
                    Success = false,
                    Message = "Beklenmeyen bir hata oluştur. Hata: " + ex.Message

                };
            }
        }

        public ResponseData GetById(int id)
        {
            try
            {
                if (id>0)
                {
                    var student = myStudentRepo.GetById(id);
                    if (student==null)
                    {
                        throw new Exception($"{id} ID numarasına ait bir kayıt bulunamadı.");
                    }
                    return new ResponseData()
                    {
                        Success = true,
                        Message = $"{id} ID numaralı öğrenci getirildi.",
                        Data = new
                        {
                            student.Id,
                            student.Name,
                            student.Surname,
                            student.RegisterDate
                        }
                    };
                }
                else
                {
                    return new ResponseData()
                    {
                        Success = false,
                        Message = "ID negatif olamaz."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData()
                {
                    Success = false,
                    Message = "Beklenmedik bir hata oluştu! Hata: "+ex.Message
                };
                
            }
        }
    }
}