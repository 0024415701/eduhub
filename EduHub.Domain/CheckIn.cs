using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Domain
{
    /// <summary>Các hình thức điểm danh được hỗ trợ.</summary>
    public enum CheckInMethod
    {
        QRCode,
        Manual
    }

    /// <summary>
    /// Ghi nhận việc điểm danh của một phiếu đăng ký.
    /// </summary>
    public class CheckIn
    {
        /// <summary>Mã định danh bản ghi điểm danh.</summary>
        public Guid Id { get; private set; }

        /// <summary>Mã phiếu đăng ký được điểm danh.</summary>
        public Guid RegistrationId { get; private set; }

        /// <summary>Thời điểm điểm danh.</summary>
        public DateTime CheckedInAt { get; private set; }

        /// <summary>Hình thức điểm danh.</summary>
        public CheckInMethod Method { get; private set; }

        private CheckIn()
        {
            Id = Guid.Empty;
            RegistrationId = Guid.Empty;
            Method = CheckInMethod.Manual;
        }

        private CheckIn(
            Guid id,
            Guid registrationId,
            DateTime checkedInAt,
            CheckInMethod method)
        {
            Id = id;
            RegistrationId = registrationId;
            CheckedInAt = checkedInAt;
            Method = method;
        }

        /// <summary>Tạo bản ghi điểm danh cho phiếu đã xác nhận.</summary>
        public static CheckIn Create(
            Registration registration,
            CheckInMethod method)
        {
            if (registration == null)
                throw new ArgumentNullException(nameof(registration));

            if (registration.Status != RegistrationStatus.Confirmed)
                throw new InvalidOperationException(
                    "Chỉ phiếu đăng ký đã xác nhận mới được điểm danh.");

            if (!Enum.IsDefined(typeof(CheckInMethod), method))
                throw new ArgumentException(
                    "Hình thức điểm danh không hợp lệ.", nameof(method));

            return new CheckIn(
                Guid.NewGuid(),
                registration.Id,
                DateTime.Now,
                method);
        }

        /// <summary>Trả về chuỗi mô tả thông tin điểm danh.</summary>
        public string Summary()
        {
            return $"Phiếu: {RegistrationId} | " +
                   $"Thời gian: {CheckedInAt:dd/MM/yyyy HH:mm:ss} | " +
                   $"Hình thức: {Method}";
        }

        /// <summary>Trả về nội dung điểm danh.</summary>
        public override string ToString()
        {
            return Summary();
        }
    }
}