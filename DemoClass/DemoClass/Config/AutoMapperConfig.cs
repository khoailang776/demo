using AutoMapper;
using DemoClass.Contracts.Class;
using DemoClass.Contracts.Student;
using DemoClass.Models;
using System;

namespace DemoClass.Config
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(
                config =>
                {
                    config.CreateMap<Class, ClassResponse>().ReverseMap();
                    config.CreateMap<Student, StudentResponse>().ReverseMap();
                }
            );
        }
    }
}
