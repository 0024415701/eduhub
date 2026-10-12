# EduHub - Các trường hợp kiểm thử

## 1. Tạo câu lạc bộ
- **Đầu vào:** Tên câu lạc bộ hợp lệ và số lượng thành viên lớn hơn 0.
- **Kết quả mong đợi:** Câu lạc bộ được tạo thành công.

## 2. Tạo sự kiện
- **Đầu vào:** Tiêu đề sự kiện hợp lệ và sức chứa lớn hơn 0.
- **Kết quả mong đợi:** Sự kiện được tạo thành công.
- **Trường hợp không hợp lệ:** Sức chứa nhỏ hơn hoặc bằng 0 phải bị từ chối.

## 3. Đăng ký tham gia sự kiện
- **Đầu vào:** Một thành viên đăng ký tham gia sự kiện.
- **Kết quả mong đợi:** Phiếu đăng ký được tạo với trạng thái `Pending` (đang chờ xử lý).

## 4. Xác nhận đăng ký
- **Đầu vào:** Một phiếu đăng ký đang ở trạng thái `Pending`.
- **Kết quả mong đợi:** Trạng thái đăng ký chuyển thành `Confirmed` (đã xác nhận).

## 5. Điểm danh
- **Đầu vào:** Một phiếu đăng ký đã được xác nhận.
- **Kết quả mong đợi:** Thông tin điểm danh được ghi nhận thành công.

## 6. Thao tác không hợp lệ
- **Đầu vào:** Một thao tác vi phạm quy tắc nghiệp vụ của hệ thống.
- **Kết quả mong đợi:** Ngoại lệ `InvalidOperationException` được phát sinh và xử lý trong chương trình Console.