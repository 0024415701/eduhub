using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Domain
{
    /// <summary>
    /// Đại diện cho sự kiện do câu lạc bộ tổ chức.
    /// </summary>
    public class Event
    {
        /// <summary>Mã định danh sự kiện.</summary>
        public Guid Id { get; private set; }

        /// <summary>Mã câu lạc bộ tổ chức sự kiện.</summary>
        public Guid ClubId { get; private set; }

        /// <summary>Tiêu đề sự kiện.</summary>
        public string Title { get; private set; }

        /// <summary>Thời gian tổ chức sự kiện.</summary>
        public DateTime Date { get; private set; }

        /// <summary>Số lượng người tham gia tối đa.</summary>
        public int Capacity { get; private set; }

        /// <summary>Cho biết sự kiện có tổ chức trực tuyến hay không.</summary>
        public bool IsOnline { get; private set; }

        private Event()
        {
            Id = Guid.Empty;
            ClubId = Guid.Empty;
            Title = string.Empty;
        }

        private Event(
            Guid id,
            Guid clubId,
            string title,
            DateTime date,
            int capacity,
            bool isOnline)
        {
            Id = id;
            ClubId = clubId;
            Title = title;
            Date = date;
            Capacity = capacity;
            IsOnline = isOnline;
        }

        /// <summary>Tạo sự kiện mới sau khi kiểm tra dữ liệu.</summary>
        public static Event Create(
            Guid clubId,
            string title,
            DateTime date,
            int capacity,
            bool isOnline)
        {
            if (clubId == Guid.Empty)
                throw new ArgumentException("Mã câu lạc bộ không hợp lệ.", nameof(clubId));

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Tiêu đề không được để trống.", nameof(title));

            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(capacity), "Sức chứa phải lớn hơn 0.");

            return new Event(
                Guid.NewGuid(),
                clubId,
                title.Trim(),
                date,
                capacity,
                isOnline);
        }

        /// <summary>
        /// Kiểm tra sự kiện còn chỗ dựa trên số lượng đã đăng ký.
        /// </summary>
        public bool HasCapacity(int registeredCount)
        {
            if (registeredCount < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(registeredCount), "Số đăng ký không được âm.");

            return registeredCount < Capacity;
        }

        /// <summary>Trả về tiêu đề và ngày tổ chức sự kiện.</summary>
        public override string ToString()
        {
            return $"{Title} - {Date:dd/MM/yyyy}";
        }
    }
}