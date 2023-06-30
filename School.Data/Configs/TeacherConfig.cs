//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using SchoolsTest.Models;

//namespace SchoolsTest.Data.Configs;

//public class TeacherConfig : IEntityTypeConfiguration<Teacher>
//{
//    public void Configure(EntityTypeBuilder<Teacher> builder)
//    {
//        builder.ToTable("Teacher");

//        builder.HasBaseType(typeof(Employee));

//        builder.HasOne(t => t.School)
//            .WithMany(t => t.Teachers);
//    }
//}
