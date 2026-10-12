using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Domain
{
    /// <summary>
    /// Đại diện cho thành viên sinh viên trong hệ thống EduHub.
    /// </summary>
    public class Member
    {
        /// <summary>Mã định danh thành viên.</summary>
        public Guid Id { get; private set; }

        /// <summary>Họ tên thành viên.</summary>
        public string Name { get; private set; }

        /// <summary>Email của thành viên.</summary>
        public string Email { get; private set; }

        /// <summary>Mã số sinh viên.</summary>
        public string StudentCode { get; private set; }

        /// <summary>Thời điểm tham gia hệ thống.</summary>
        public DateTime JoinedAt { get; private set; }

        private Member()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Email = string.Empty;
            StudentCode = string.Empty;
        }

        private Member(
            Guid id,
            string name,
            string email,
            string studentCode,
            DateTime joinedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            StudentCode = studentCode;
            JoinedAt = joinedAt;
        }

        /// <summary>
        /// Tạo thành viên mới sau khi kiểm tra dữ liệu đầu vào.
        /// </summary>
        public static Member Create(
            string name,
            string email,
            string studentCode,
            DateTime joinedAt)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên không được để trống.", nameof(name));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                throw new ArgumentException("Email không hợp lệ.", nameof(email));

            if (string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Mã sinh viên không được để trống.", nameof(studentCode));

            if (joinedAt > DateTime.Now)
                throw new ArgumentException("Ngày tham gia không được ở tương lai.", nameof(joinedAt));

            return new Member(
                Guid.NewGuid(),
                name.Trim(),
                email.Trim(),
                studentCode.Trim(),
                joinedAt);
        }

        /// <summary>Kiểm tra thành viên có thông tin hợp lệ để hoạt động.</summary>
        public bool IsActive()
        {
            return Id != Guid.Empty
                && !string.IsNullOrWhiteSpace(Name)
                && !string.IsNullOrWhiteSpace(Email);
        }

        /// <summary>Trả về tên và mã sinh viên.</summary>
        public override string ToString()
        {
            return $"{Name} ({StudentCode})";
        }
    }
}