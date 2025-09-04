namespace HeaLEOO.Data.IEntityTypeConfiguration
{
    public class ClinicDoctorsConfig : IEntityTypeConfiguration<ClinicDoctors>
    {
        public void Configure(EntityTypeBuilder<ClinicDoctors> builder)
        {
            builder.HasKey(cd => new { cd.ClinicId, cd.DoctorId });
            builder.HasOne(cd => cd.Clinic)
                   .WithMany(c => c.ClinicDoctors)
                   .HasForeignKey(cd => cd.ClinicId);
            builder.HasOne(cd => cd.Doctor)
                   .WithMany(d => d.ClinicDoctors)
                   .HasForeignKey(cd => cd.DoctorId);
        }
    }
}
