using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SchoolApp.Models;
using SchoolApp.Dtos;

namespace SchoolApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Result, ResultDto>();
            Mapper.CreateMap<ResultDto, Result>();
            Mapper.CreateMap<Stage, StageDto>();
            Mapper.CreateMap<StageDto, Stage>();
            Mapper.CreateMap<Student, StudentDto>();
            Mapper.CreateMap<StudentDto, Student>();
            Mapper.CreateMap<Subject, SubjectDto>();
            Mapper.CreateMap<SubjectDto, Subject>();
            Mapper.CreateMap<Teacher, TeacherDto>();
            Mapper.CreateMap<TeacherDto, Teacher>();
        }
    }
}