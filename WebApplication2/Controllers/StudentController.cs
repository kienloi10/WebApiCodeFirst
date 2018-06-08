using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;
using static WebApplication2.ViewModels.StudentModel;

namespace WebApplication2.Controllers
{
    public class StudentController : ApiController
    {
       
       
        private ApiDBContext _db;
        public StudentController()
        {
            this._db = new ApiDBContext();

        }

        /**
        * @api {GET} /student/GetAll Lấy thông tin tất cả các sv
        * @apiGroup SV 
        * @apiPermission none
        * 
        * @apiSuccessExample {json} Response:
        * [
        *   {
        *       "MaSV": "ABC",
        *       "HoTenSV": "Nguyễn Căn A",
        *       "TenLop": "CNTT1",
        *       "DiaChi": "1 đường Số 7"
        *   },
        *   {
        *       "MaSV": "ABCD",
        *       "HoTenSV": "Nguyễn Thị A",
        *       "TenLop": "CNTT2",
        *       "DiaChi":"3 Lê Lợi"
        *   }
        *     
        * ]
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample {json} Error-Response:
        * {
        *      "Error":[        
        *      ]
        * }
        */
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listsvs = this._db.Students.Select(x => new StudentModel()
            {
                MaSV = x.MSSV,
                HoTenSV = x.HoTen,
                DiaChi = x.DiaChi

            });
            return Ok(listsvs);
        }


        /**
        * @api {GET} /student/GetById?Id=Id Lấy thông tin lớp theo Id
        * @apiGroup SV
        * @apiPermission none
        * 
        * @apiParam {int} Id Id của sv  
        * 
        * @apiExample Example usage: 
        * 
        * /api/student/GetById?Id=1
        * 
        * @apiSuccessExample {json} Response:
        *   {
        *       "MaSV": "ABC",
        *       "HoTenSV": "Nguyễn Căn A",
        *       "TenLop": "CNTT1",
        *       "DiaChi": "1 đường Số 7"
        *   }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample {json} Error-Response:
        * {
        *      "Error":[
        *          "Không tìm thấy lớp này!"
        *      ]
        * }
        */
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var sv = _db.Students.FirstOrDefault(x => x.Id == id);

            if (sv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy sinh viên");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new StudentModel(sv));
            }

            return httpActionResult;
        }



        /**
        * @api [Post] /student/TaoSV Tạo 1 SV mới
        * @apigroup SV
        * @apiPermission none 
        * 
        * @apiParam [string] MSSV Mã của sv mới
        * @apiParam [string] HoTen HoTen của sv mới
        * @apiParam [string] DiaChi DiaChi của sv mới
        * 
        * @apiParamExample [json] Request-Example:
        * {
        *   MSSV:"N14DCCN043",
        *   HoTen:"Dong Kien Loi",
        *   DiaChi:"1 Nguyen Trai"
        * }
        * 
        * @apiSuccess [string] MSSV Mã của sv vừa tạo
        * @apiSuccess [string] HoTen Họ Tên của sv vừa tạo
        * @apiSuccess [Id] Id của sv mới
        * 
        * @apiSuccessExample [json] Success-Response:
        * {
        *   Id:1,
        *   MSSV:"N14DCCN043",
        *   HoTen:"Dong Kien Loi",
        *   DiaChi:"1 Nguyen Trai"
        * 
        * }
        * 
        * @apiError [400] (string[]) Error các mảng lỗi
        * 
        * @apiErrorExample {json}
        * {
        *   "Errors":[
        *       MaSV là bat buoc,
        *       TenSV la bat buoc
        *   
        *   ]
        * }

        * */
        [HttpPost]
        public IHttpActionResult TaoSV(CreateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MaSV))
            {
                errors.Add("Mã sv la bat buoc");
            }

            if (string.IsNullOrEmpty(model.HoTenSV))
            {
                errors.Add("Tên sv la bat buoc");
            }

            if (errors.Errors.Count == 0)
            {
                Student sv = new Student();
                sv.MSSV = model.MaSV;
                sv.HoTen = model.HoTenSV;
                sv.DiaChi = model.DiaChi;

                sv = _db.Students.Add(sv);

                this._db.SaveChanges();

                StudentModel viewModel = new StudentModel(sv);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }



        /**
         * @api {PUT} /student/CapNhatSV Cập nhật thông tin một sv
         * @apiGroup SV
         * @apiPermission none
         * 
         * @apiParam {int} Id Id lớp cần cập nhật
         * @apiParam {string} TenLop Tên của lớp cần cập nhật
         * @apiParam {string} MaLop Mã lớp của lớp cần cập nhật
         * @apiParam {string} DiaChi Mã lớp của lớp cần cập nhật
         * 
         * @apiParamExample {json} Request-Example:
         *   {
        *       "MaSV": "ABC",
        *       "HoTenSV": "Nguyễn Căn B",
        *       "TenLop": "CNTT8",
        *       "DiaChi":"3 Lê Lợi"
        *       
        *   }
         * 
         * @apiSuccess {int} Id Id lớp vừa cập nhật
         * @apiSuccess {string} TenLop Tên của lớp vừa cập nhật
         * @apiSuccess {string} MaLop Mã lớp của lớp vừa cập nhật
         * 
         * @apiSuccessExample {json} Response:
         *   {
        *       "MaSV": "ABC",
        *       "HoTenSV": "Nguyễn Căn B",
        *       "TenLop": "CNTT8",
        *       "DiaChi":"3 Lê Lợi"
        *       
        *   }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "Không tìm thấy lớp này!"
         *      ]
         * }
         */

        [HttpPut]
        public IHttpActionResult CapNhatSV(UpdateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            Student sv = this._db.Students.FirstOrDefault(x => x.Id == model.Id);

            if (sv == null)
            {
                errors.Add("Không tìm th?y sv");

                httpActionResult = Ok(errors);
            }
            else
            {
                sv.MSSV = model.MaSV ?? model.MaSV;
                sv.HoTen = model.HoTenSV ?? model.HoTenSV;
                sv.DiaChi = model.DiaChi ?? model.DiaChi;

                this._db.Entry(sv).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new StudentModel(sv));
            }

            return httpActionResult;
        }


    }
}