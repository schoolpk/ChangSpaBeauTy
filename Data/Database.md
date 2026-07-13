# Hướng dẫn chi tiết: Khôi phục Database ChangSpaBeauTy

## 1. Môi trường cần có trước khi làm

| Công cụ | Yêu cầu | Cách kiểm tra đã cài chưa |
|---|---|---|
| **SQL Server LocalDB** | Bản `MSSQLLocalDB` (thường đi kèm Visual Studio khi cài workload "ASP.NET and web development") | Mở CMD gõ: `sqllocaldb info` → nếu thấy `MSSQLLocalDB` trong danh sách là đã có |
| **SQL Server Management Studio (SSMS)** | Bản 18 trở lên (khuyên dùng bản mới nhất) | Mở Start Menu tìm "Microsoft SQL Server Management Studio" |
| **Dung lượng ổ đĩa trống** | Tối thiểu vài trăm MB | Tùy kích thước file backup trong repo |

> Nếu máy chưa có LocalDB: mở **Visual Studio Installer** → **Modify** → tick chọn workload **ASP.NET and web development** → phần **Individual components** tìm và tick **SQL Server Express LocalDB** → Install.

> Nếu chưa có SSMS: tải miễn phí tại `https://aka.ms/ssmsfullsetup`.

---

## 2. Xác định máy chủ (Server) sẽ kết nối

Project mặc định dùng LocalDB, tên instance là:

```
(localdb)\MSSQLLocalDB
```

Đây **không phải** SQL Server cài đầy đủ, mà là bản nhẹ chạy ngầm theo user Windows hiện tại — không cần start dịch vụ thủ công, SSMS sẽ tự khởi động khi kết nối.

Khi mở SSMS, ở màn hình **Connect to Server**:

- **Server type**: Database Engine
- **Server name**: gõ `(localdb)\MSSQLLocalDB`
- **Authentication**: Windows Authentication

Bấm **Connect**.

---

## 3. Xác định file backup trong repo

Sau khi `git clone`/`git pull` repo về, kiểm tra thư mục:

```
ChangSpaBeauty/Database/
```

Trong đó sẽ có loại file:

- `ChangSpaBeauTy.bak` → làm theo **Mục 4**


---

## 4. Khôi phục từ file `.bak`

**Bản chất**: đây là bản sao lưu vật lý toàn bộ database — restore xong sẽ giống 100% database gốc.

### Các bước:

1. Trong SSMS, ở cửa sổ **Object Explorer** (bên trái), chuột phải vào **Databases** → chọn **Restore Database...**

2. Trong hộp thoại hiện ra:
   - **Source**: chọn radio **Device**
   - Bấm nút **`...`** bên cạnh ô trống
   - Trong cửa sổ **Select backup devices** → bấm **Add**
   - Duyệt đến đúng đường dẫn file trong repo, ví dụ:
     ```
     D:\Project\ChangSpaBeauty\Database\ChangSpaBeauTy.bak
     ```
   - Chọn file → **OK** → **OK** (đóng cửa sổ Select backup devices)

3. Kiểm tra ở bảng phía dưới (**Backup sets to restore**) đã tick chọn dòng backup set hiện ra.

4. Vào tab **Files** (bên trái hộp thoại) — kiểm tra đường dẫn file `.mdf`/`.ldf` đích, thường để mặc định là được (SSMS tự đề xuất đường dẫn LocalDB).

5. Vào tab **Options**:
   - Tick **Overwrite the existing database (WITH REPLACE)** nếu máy bạn *đã từng* có DB `ChangSpaBeauTy` cũ và muốn ghi đè.

6. Bấm **OK** để bắt đầu restore. Chờ thông báo **"Restore completed successfully"**.

---
> ⚠️ Import sẽ **tạo database mới**, không ghi đè lên database đã tồn tại cùng tên. Nếu máy bạn đã có sẵn DB `ChangSpaBeauTy` (rỗng hoặc cũ), cần xóa nó trước (chuột phải DB → **Delete**) rồi mới Import lại.

---

## 5. Kiểm tra sau khi khôi phục

Dù dùng cách nào ở Mục 4, sau khi xong hãy kiểm tra lại:

1. Trong **Object Explorer**, mở rộng **Databases** → thấy DB tên **ChangSpaBeauTy** xuất hiện.
2. Mở rộng DB đó → **Tables** → phải thấy đủ các bảng: `Product`, `Category`, `User`, `ShoppingCart`, `CartItem`, `Order`, `OrderDetail`, `Notification`.
3. Chuột phải bảng `Product` → **Select Top 1000 Rows** → phải thấy có dữ liệu (không rỗng).

Nếu đủ các bảng và có dữ liệu → khôi phục thành công, có thể chạy project.

---

## 6. Các lỗi thường gặp khi khôi phục

| Lỗi | Nguyên nhân | Cách khắc phục |
|---|---|---|
| `Cannot connect to (localdb)\MSSQLLocalDB` | Chưa cài LocalDB | Cài lại theo hướng dẫn Mục 1 |
| `The media family on device ... is incorrectly formed` | File `.bak` bị lỗi/tải thiếu (Git LFS chưa pull đủ, hoặc file bị corrupt khi commit) | Pull lại repo, kiểm tra dung lượng file `.bak` có đúng như trên máy gốc không |
| `Database 'ChangSpaBeauTy' already exists` (khi Import .bacpac) | DB cùng tên đã tồn tại | Xóa DB cũ trước khi Import, hoặc đổi tên DB đích |
| Restore xong nhưng bảng rỗng | File backup gốc lấy nhầm lúc DB chưa có dữ liệu mẫu | Xin lại file backup mới nhất từ người tạo repo |
| `Access is denied` khi restore | Không có quyền ghi vào thư mục Data của LocalDB | Chạy SSMS với quyền Administrator, hoặc đổi đường dẫn file đích trong tab **Files** khi restore |
