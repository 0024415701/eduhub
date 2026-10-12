using System;
using System.Collections.Generic;
using System.Linq;

namespace EduHub.Domain
{
    /// <summary>
    /// Đại diện cho câu lạc bộ sinh viên.
    /// </summary>
    public class Club
    {
        /// <summary>Mã định danh câu lạc bộ.</summary>
        public Guid Id { get; private set; }

        /// <summary>Tên câu lạc bộ.</summary>
        public string Name { get; private set; }

        /// <summary>Mô tả câu lạc bộ.</summary>
        public string Description { get; private set; }

        /// <summary>Thời điểm tạo câu lạc bộ.</summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>Danh sách thành viên của câu lạc bộ.</summary>
        public List<Member> Members { get; private set; }

        private Club()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Members = new List<Member>();
        }

        private Club(
            Guid id,
            string name,
            string description,
            DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedAt = createdAt;
            Members = new List<Member>();
        }

        /// <summary>Tạo câu lạc bộ mới.</summary>
        public static Club Create(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên câu lạc bộ không được để trống.", nameof(name));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Mô tả không được để trống.", nameof(description));

            return new Club(
                Guid.NewGuid(),
                name.Trim(),
                description.Trim(),
                DateTime.Now);
        }

        /// <summary>Thêm thành viên vào câu lạc bộ.</summary>
        public void AddMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            if (!member.IsActive())
                throw new InvalidOperationException("Thành viên không hợp lệ.");

            if (Members.Any(m => m.Id == member.Id))
                throw new InvalidOperationException("Thành viên đã có trong câu lạc bộ.");

            Members.Add(member);
        }

        /// <summary>Trả về số lượng thành viên hiện tại.</summary>
        public int MemberCount()
        {
            return Members.Count;
        }

        /// <summary>Trả về tên câu lạc bộ.</summary>
        public override string ToString()
        {
            return $"{Name} - {MemberCount()} thành viên";
        }
    }
}