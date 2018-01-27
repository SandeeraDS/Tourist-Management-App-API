using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrabodaApi.Controllers;

namespace PrabodaApi.Entities
{
    public partial class TouristManagerContext : DbContext
    {
        public virtual DbSet<BookedBy> BookedBy { get; set; }
        public virtual DbSet<CabBooking> CabBooking { get; set; }
        public virtual DbSet<CabComment> CabComment { get; set; }
        public virtual DbSet<CabDetails> CabDetails { get; set; }
        public virtual DbSet<CabRating> CabRating { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<ChatGroup> ChatGroup { get; set; }
        public virtual DbSet<ChatGrouping> ChatGrouping { get; set; }
        public virtual DbSet<ChatMember> ChatMember { get; set; }
        public virtual DbSet<ChatWhoToWhom> ChatWhoToWhom { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelComment> HotelComment { get; set; }
        public virtual DbSet<HotelRating> HotelRating { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<RoomBooking> RoomBooking { get; set; }
        public virtual DbSet<RoomDetails> RoomDetails { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<TourGuide> TourGuide { get; set; }
        public virtual DbSet<TourGuideBooking> TourGuideBooking { get; set; }
        public virtual DbSet<TourGuideComment> TourGuideComment { get; set; }
        public virtual DbSet<TourGuideRating> TourGuideRating { get; set; }
        public virtual DbSet<Tourist> Tourist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Data Source=pro5tm.database.windows.net;Initial Catalog=TouristManager;Integrated Security=False;User ID=prabodha;Password=Manoranga13308;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookedBy>(entity =>
            {
                entity.HasKey(e => new { e.TouristId, e.BookingId })
                    .HasName("PK_BookedBy");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookedBy)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BookedBy_CabBooking1");

                entity.HasOne(d => d.BookingNavigation)
                    .WithMany(p => p.BookedBy)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BookedBy_RoomBooking");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.BookedBy)
                    .HasForeignKey(d => d.TouristId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BookedBy_Tourist");
            });

            modelBuilder.Entity<CabBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK_CabBooking");

                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.Property(e => e.BeginigLocation).HasColumnType("nchar(10)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.CabBooking)
                    .HasForeignKey(d => d.TouristId)
                    .HasConstraintName("FK_CabBooking_Tourist");
            });

            modelBuilder.Entity<CabComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_CabComment_1");

                entity.Property(e => e.CommentId).ValueGeneratedNever();

                entity.Property(e => e.CabComment1).HasColumnName("CabComment");

                entity.Property(e => e.UserName).HasColumnType("nchar(20)");

                entity.HasOne(d => d.Cab)
                    .WithMany(p => p.CabComment)
                    .HasForeignKey(d => d.CabId)
                    .HasConstraintName("FK_CabComment_CabDetails");
            });

            modelBuilder.Entity<CabDetails>(entity =>
            {
                entity.HasKey(e => e.CabId)
                    .HasName("PK_CabDetails_1");

                entity.Property(e => e.ContactNo).HasMaxLength(50);

                entity.Property(e => e.CurrentLocation).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<CabRating>(entity =>
            {
                entity.HasKey(e => new { e.TouristId, e.CabId })
                    .HasName("PK_CabRating");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.CabRating)
                    .HasForeignKey(d => d.TouristId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CabRating_CabDetails");

                entity.HasOne(d => d.TouristNavigation)
                    .WithMany(p => p.CabRating)
                    .HasForeignKey(d => d.TouristId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CabRating_Tourist");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.ChatId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<ChatGroup>(entity =>
            {
                entity.Property(e => e.ChatGroupId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GroupName).HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<ChatGrouping>(entity =>
            {
                entity.HasKey(e => new { e.ChatMemberId, e.ChatGroupId })
                    .HasName("PK_ChatGrouping");

                entity.HasOne(d => d.ChatGroup)
                    .WithMany(p => p.ChatGrouping)
                    .HasForeignKey(d => d.ChatGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ChatGrouping_ChatGroup");

                entity.HasOne(d => d.ChatMember)
                    .WithMany(p => p.ChatGrouping)
                    .HasForeignKey(d => d.ChatMemberId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ChatGrouping_ChatMember");
            });

            modelBuilder.Entity<ChatMember>(entity =>
            {
                entity.Property(e => e.ChatMemberId).ValueGeneratedNever();

                entity.Property(e => e.ChantName)
                    .IsRequired()
                    .HasColumnName("Chant Name")
                    .HasColumnType("nchar(10)");
            });

            modelBuilder.Entity<ChatWhoToWhom>(entity =>
            {
                entity.HasKey(e => new { e.SenderId, e.ReceiverId })
                    .HasName("PK_ChatWhoToWhom");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatWhoToWhom)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ChatWhoToWhom_Chat");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.ChatWhoToWhomReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ChatWhoToWhom_TourGuide1");

                entity.HasOne(d => d.ReceiverNavigation)
                    .WithMany(p => p.ChatWhoToWhomReceiverNavigation)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ChatWhoToWhom_Tourist1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.ChatWhoToWhomSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ChatWhoToWhom_TourGuide");

                entity.HasOne(d => d.SenderNavigation)
                    .WithMany(p => p.ChatWhoToWhomSenderNavigation)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ChatWhoToWhom_Tourist");
            });

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.HasKey(e => e.FriendshipId)
                    .HasName("PK_Friends");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendsFriend)
                    .HasForeignKey(d => d.FriendId)
                    .HasConstraintName("FK_Friends_Tourist1");

                entity.HasOne(d => d.My)
                    .WithMany(p => p.FriendsMy)
                    .HasForeignKey(d => d.MyId)
                    .HasConstraintName("FK_Friends_Tourist");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<HotelComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_HotelComment");

                entity.Property(e => e.HotelComment1)
                    .HasColumnName("HotelComment")
                    .HasColumnType("nchar(1000)");

                entity.Property(e => e.UserName).HasColumnType("nchar(20)");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelComment)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelComment_Hotel");
            });

            modelBuilder.Entity<HotelRating>(entity =>
            {
                entity.HasKey(e => new { e.TouristId, e.HotelId })
                    .HasName("PK_HotelRating");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelRating)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HotelRating_Hotel");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.HotelRating)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_HotelRating_Payments");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.HotelRating)
                    .HasForeignKey(d => d.TouristId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_HotelRating_Tourist");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK_Payments");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TouristId)
                    .HasConstraintName("FK_Payments_Tourist1");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK_Posts");

                entity.Property(e => e.PostId).ValueGeneratedOnAdd();

                entity.Property(e => e.PostDate).HasColumnType("varchar(50)");

                entity.HasOne(d => d.From)
                    .WithMany(p => p.PostsFrom)
                    .HasForeignKey(d => d.FromId)
                    .HasConstraintName("FK_Posts_Tourist");

                entity.HasOne(d => d.PostNavigation)
                    .WithOne(p => p.PostsPostNavigation)
                    .HasForeignKey<Posts>(d => d.PostId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Posts_Tourist1");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("PK_Reservations");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_Reservations_Hotel");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TouristId)
                    .HasConstraintName("FK_Reservations_Tourist");
            });

            modelBuilder.Entity<RoomBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK_RoomBooking");

                entity.Property(e => e.BookingId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Booking)
                    .WithOne(p => p.RoomBooking)
                    .HasForeignKey<RoomBooking>(d => d.BookingId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RoomBooking_Payments");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.RoomBooking)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_RoomBooking_RoomType");
            });

            modelBuilder.Entity<RoomDetails>(entity =>
            {
                entity.HasKey(e => new { e.HotelId, e.TypeId })
                    .HasName("PK_RoomType");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.RoomDetails)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RoomType_Hotel");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.RoomDetails)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RoomDetails_RoomType");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId).ValueGeneratedNever();

                entity.Property(e => e.RoomTypeName).HasColumnType("nchar(20)");
            });

            modelBuilder.Entity<TourGuide>(entity =>
            {
                entity.HasKey(e => e.GuideId)
                    .HasName("PK_TourGuide_1");

                entity.Property(e => e.GuideId).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Guide)
                    .WithOne(p => p.InverseGuide)
                    .HasForeignKey<TourGuide>(d => d.GuideId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TourGuide_TourGuide");
            });

            modelBuilder.Entity<TourGuideBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK_TourGuideBooking");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Guide)
                    .WithMany(p => p.TourGuideBooking)
                    .HasForeignKey(d => d.GuideId)
                    .HasConstraintName("FK_TourGuideBooking_TourGuide");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.TourGuideBooking)
                    .HasForeignKey(d => d.TouristId)
                    .HasConstraintName("FK_TourGuideBooking_Tourist");
            });

            modelBuilder.Entity<TourGuideComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK_TourGuideComment");

                entity.Property(e => e.CommentId).ValueGeneratedOnAdd();

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Comment)
                    .WithOne(p => p.TourGuideComment)
                    .HasForeignKey<TourGuideComment>(d => d.CommentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TourGuideComment_TourGuide");
            });

            modelBuilder.Entity<TourGuideRating>(entity =>
            {
                entity.HasKey(e => new { e.TouristId, e.TourGuideId })
                    .HasName("PK_TourGuideRating_1");

                entity.HasOne(d => d.TourGuide)
                    .WithMany(p => p.TourGuideRating)
                    .HasForeignKey(d => d.TourGuideId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TourGuideRating_TourGuide");

                entity.HasOne(d => d.Tourist)
                    .WithMany(p => p.TourGuideRating)
                    .HasForeignKey(d => d.TouristId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TourGuideRating_Tourist");
            });

            modelBuilder.Entity<Tourist>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });
        }

        public static implicit operator TouristManagerContext(TouristController v)
        {
            throw new NotImplementedException();
        }
    }
}