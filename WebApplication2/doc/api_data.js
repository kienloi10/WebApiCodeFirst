define({ "api": [
  {
    "type": "",
    "url": "[Post]",
    "title": "/Class/TaoLop Tạo 1 lớp mới",
    "group": "LOP",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "optional": true,
            "field": "string",
            "description": "<p>MaLop Mã của lớp mới</p>"
          },
          {
            "group": "Parameter",
            "optional": true,
            "field": "int",
            "description": "<p>[SoLuongLop]</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "[json] Request-Example:",
          "content": "{\n  MaLop:\"D14CQCN01\",\n  TenLop:\"Công nghệ thông tin\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": true,
            "field": "string",
            "description": "<p>MaLop Mã của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "optional": true,
            "field": "Id",
            "description": "<p>Id của lớp mới</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "[json] Success-Response:",
          "content": "{\n  Id:1,\n  MaLop:\"D14CQCN01\",\n  TenLop: \"Công nghệ thông tin\"\n\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>(string[]) Error các mảng lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "{",
          "content": "{\n  \"Errors\":[\n      MaLop là bat buoc,\n      TenLop la bat buoc\n  \n  ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "LOP",
    "name": "Post"
  }
] });
