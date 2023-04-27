using Autofac;
using AutoMapper;
using FormProject.Application.Mapping;
using FormProject.Application.Services;
using FormProject.Domain.Repositories;
using FormProject.Infrastructure.Repositories;

namespace FormProject.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Dependency Injection için gerekli olan düzenlemeler Dependency container içerisinde yapıldı

            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<FormService>().As<IFormService>().InstancePerLifetimeScope();
            builder.RegisterType<FieldService>().As<IFieldService>().InstancePerLifetimeScope();

            builder.RegisterType<FormRepository>().As<IFormRepository>().InstancePerLifetimeScope();
            builder.RegisterType<FieldRepository>().As<IFieldRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerLifetimeScope();

            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<MappingProfile>(); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
            }
            )).AsSelf().SingleInstance();



            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion
            base.Load(builder);
        }
    }
}
