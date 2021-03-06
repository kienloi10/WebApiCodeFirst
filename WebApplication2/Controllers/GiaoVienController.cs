﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class GiaoVienController : ApiController
    {


        private ApiDBContext _db;
        public GiaoVienController()
        {
            this._db = new ApiDBContext();

        }

        /**
        * @api {GET} /giaovien/GetAll Lấy thông tin tất cả các gv
        * @apiGroup GV 
        * @apiPermission none
        * 
        * @apiSuccessExample {json} Response:
        * [
        *   {
        *       
        *       "HoTen": "Nguyễn Căn A",
        *       
        *   },
        *   {
        *      
        *       "HoTen": "Nguyễn Thị A",
        *       
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
            var listgvs = this._db.GiaoViens.Select(x => new GiaoVienModel()
            {
                HoTen = x.HoTen

            });
            return Ok(listgvs);
        }

        /**
        * @api {GET} /giaovien/GetById?Id=Id Lấy thông tin lớp theo Id
        * @apiGroup GV
        * @apiPermission none
        * 
        * @apiParam {int} Id Id của gv
        * 
        * @apiExample Example usage: 
        * 
        * /api/giaovien/GetById?Id=1
        * 
        * @apiSuccessExample {json} Response:
        *   {
        *       
        *       "HoTen": "Nguyễn Căn A",
        *       
        *   }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample {json} Error-Response:
        * {
        *      "Error":[
        *          "Không tìm thấy gv này!"
        *      ]
        * }
        */
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var gv = _db.GiaoViens.FirstOrDefault(x => x.Id == id);

            if (gv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy Gíao viên");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new GiaoVienModel(gv));
            }

            return httpActionResult;
        }

        /**
        * @api [Post] /giaovien/TaoGV Tạo 1 Gv mới
        * @apigroup GV  
        * @apiPermission none 
        * 
        * @apiParam [string] TenGV Ho Ten của gv mới 
        * 
        * @apiParamExample [json] Request-Example:
        * {
        *   TenGV:"Nguyễn Thị A"
        * }
        * 
        * @apiSuccess [string] TenGV Ho Ten của gv mới
        * @apiSuccess [Id] Id của gv mới
        * 
        * @apiSuccessExample [json] Success-Response:
        * {
        *   Id:1,
        *   TenGV:"Nguyễn Thị A"
        * 
        * }
        * 
        * @apiError [400] (string[]) Error các mảng lỗi
        * 
        * @apiErrorExample {json}
        * {
        *   "Errors":[
        *       TenGV la bat buoc
        *   
        *   ]
        * }

        * */
        [HttpPost]
        public IHttpActionResult TaoGV(CreateGiaoVienModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            
            if (string.IsNullOrEmpty(model.TenGV))
            {
                errors.Add("Tên GV là bat buoc");
            }

            if (errors.Errors.Count == 0)
            {
                GiaoVien gv = new GiaoVien();
                gv.HoTen = model.TenGV;


                gv = _db.GiaoViens.Add(gv);

                this._db.SaveChanges();

                GiaoVienModel viewModel = new GiaoVienModel(gv);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }


        /**
         * @api {PUT} /giaovien/CapNhatGV Cập nhật thông tin một lớp
         * @apiGroup GV
         * @apiPermission none
         * 
         * @apiParam {int} Id Id gv cần cập nhật
         * @apiParam {string} HoTen Tên của gv cần cập nhật
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *   Id:1,
         *   TenGV:"Nguyễn Thị A"
         * 
         * }
         * 
         * @apiSuccess {int} Id Id gv vừa cập nhật
         * @apiSuccess {string} HoTen Tên của gv cần cập nhật
         * @apiSuccessExample {json} Response:
         * {
         *   Id:1,
         *   TenGV:"Nguyễn Thị A"
         * 
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample {json} Error-Response:
         * {
         *      "Error":[
         *          "Không tìm thấy gv này!"
         *      ]
         * }
         */

        [HttpPut]
        public IHttpActionResult CapNhatGV(UpdateGiaoVienModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            GiaoVien gv = this._db.GiaoViens.FirstOrDefault(x => x.Id == model.Id);

            if (gv == null)
            {
                errors.Add("Không tìm thấy gv");

                httpActionResult = Ok(errors);
            }
            else
            {
                gv.HoTen = model.TenGV ?? model.TenGV;
               

                this._db.Entry(gv).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new GiaoVienModel(gv));
            }

            return httpActionResult;
        }


    }
}
