# ChangSpaBeauTy – Shop bán hàng trực tuyến

## Giới thiệu

**ChangSpaBeauTy** là một website thương mại điện tử chuyên về sản phẩm chăm sóc sắc đẹp và spa

Dự án mô phỏng một cửa hàng mỹ phẩm/spa trực tuyến hoàn chỉnh: từ trang giới thiệu sản phẩm, giỏ hàng, thanh toán, cho tới trang quản trị dành cho admin — được phát triển theo kiến trúc **Clean Architecture** để đảm bảo mã nguồn rõ ràng, dễ bảo trì và dễ kiểm thử.

Ý tưởng bắt đầu từ nhu cầu thực tế: nhóm phát triển thường gặp khó khăn khi tìm sản phẩm làm đẹp uy tín, chất lượng, nên mong muốn xây dựng một hệ thống bán hàng online đơn giản, dễ sử dụng, giúp khách hàng dễ dàng tìm kiếm sản phẩm phù hợp, đồng thời là môi trường để nhóm rèn luyện kỹ năng lập trình web và quản lý dữ liệu sản phẩm.

## Mục đích

- Xây dựng một hệ thống bán hàng online đơn giản, thân thiện, dễ sử dụng.
- Giúp khách hàng dễ dàng tìm kiếm, lọc và mua các sản phẩm làm đẹp phù hợp.
- Rèn luyện và áp dụng kỹ năng lập trình web full-stack (ASP.NET Core MVC, EF Core, SQL Server).
- Thực hành quy trình phát triển phần mềm chuyên nghiệp: kiến trúc phân lớp (Clean Architecture), kiểm thử tự động (Unit Test), quản lý mã nguồn theo GitHub Flow.
- Cung cấp đầy đủ tính năng của một website thương mại điện tử thực tế: danh mục sản phẩm, giỏ hàng, đặt hàng, quản lý đơn hàng, thông báo, quản trị hệ thống.

## Mô hình

Dự án được tổ chức theo **Clean Architecture** với 4 tầng chính, tách biệt rõ trách nhiệm:

```
ChangSpaBeauty.Domain          → Thực thể nghiệp vụ (Entities), Interfaces cốt lõi
ChangSpaBeauty.Application     → Business logic, Services, DTOs, Interfaces
ChangSpaBeauty.Infrastructure  → EF Core, Repository, kết nối SQL Server
ChangSpaBeauty.Web             → ASP.NET Core MVC (Controllers, Views, Razor)
ChangSpaBeauty.Api             → Web API (Swagger/OpenAPI)
ChangSpaBeauty.Tests           → Unit Test (NUnit + Moq)
```

**Nguyên tắc phụ thuộc:** `Web/Api → Infrastructure → Application → Domain`
Tầng Application không phụ thuộc trực tiếp vào Infrastructure (AppDbContext); các thao tác dữ liệu được trừu tượng hóa qua Repository Interface, cài đặt cụ thể nằm ở tầng Infrastructure.

### Công nghệ sử dụng

| Thành phần | Công nghệ |
|---|---|
| Backend Framework | ASP.NET Core MVC 8 (C#, Razor) |
| ORM | Entity Framework Core 8/9 |
| Cơ sở dữ liệu | SQL Server |
| Kiểm thử | NUnit 4 + Moq |
| Xác thực | Cookie Authentication + BCrypt (hash mật khẩu) |
| Quản lý mã nguồn | Git – GitHub Flow |
| Giao diện | CSS thuần (custom properties) – tông màu hồng/rose (`#D6336C`, `#FF4081`, `#FFB6C1`, `#FFF5F8`), font Google Fonts (Playfair Display + DM Sans) |

### Tính năng chính

- **Sản phẩm:** duyệt, tìm kiếm, lọc theo danh mục/thương hiệu/từ khóa, sidebar động, kiểm tra tồn kho, hiển thị hết hàng.
- **Giỏ hàng & thanh toán:** thêm vào giỏ (AJAX), Mua ngay, kiểm soát số lượng theo tồn kho, quy trình thanh toán có bước tiến trình.
- **Quản lý đơn hàng:** đặt hàng, hủy đơn (khi đang chờ/đã xác nhận), khách hàng chỉnh sửa đơn (địa chỉ, SĐT, số lượng, xóa sản phẩm khi đơn còn "chờ xác nhận"), admin quản lý trạng thái theo tab lọc.
- **Thông báo:** hệ thống chuông thông báo lưu trong DB, đánh dấu đã đọc, xóa tất cả; hai chiều giữa khách hàng ↔ admin.
- **Trang quản trị (Admin):** quản lý người dùng/sản phẩm/danh mục theo tab, phân quyền theo vai trò (Role-based Authorization).
- **Xác thực:** đăng nhập/đăng ký bằng cookie, mã hóa mật khẩu BCrypt, popup yêu cầu đăng nhập khi thao tác trên trang chi tiết sản phẩm.
- **Kiểm thử:** bộ Unit Test với NUnit, bao phủ các nhóm Auth/User, Product, Cart, Order.

## Cách cài về máy

1. **Clone dự án về máy:**
   ```bash
   git clone <đường-dẫn-repository-của-dự-án>
   cd ChangSpaBeauTy
   ```

2. **Mở solution bằng Visual Studio:**
   - Mở file `ChangSpaBeauty.sln`.

3. **Cấu hình chuỗi kết nối cơ sở dữ liệu:**
   - Copy file mẫu `appsettings.Example.json` thành `appsettings.json` trong thư mục `ChangSpaBeauty.Web`.
   - Cập nhật `ConnectionStrings:DefaultConnection` trỏ tới SQL Server của bạn, ví dụ:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ChangSpaBeauTy;Trusted_Connection=True;TrustServerCertificate=True"
     }
     ```


4. **Khôi phục các gói NuGet:**
   ```bash
   dotnet restore
   ```

5. **Tạo cơ sở dữ liệu (Migration):**
   ```bash
   dotnet ef database update --project ChangSpaBeauty.Infrastructure --startup-project ChangSpaBeauty.Web
   ```

6. **Chạy ứng dụng:**
   - Trong Visual Studio: chọn project khởi động là `ChangSpaBeauty.Web`, nhấn `F5` (hoặc `Ctrl+F5`).
   - Hoặc dùng dòng lệnh:
     ```bash
     cd ChangSpaBeauty.Web
     dotnet run
     ```
   - Truy cập ứng dụng tại địa chỉ được in ra console (mặc định: `https://localhost:7157` hoặc `http://localhost:5019`).

7. **(Tùy chọn) Chạy Unit Test:**
   ```bash
   dotnet test ChangSpaBeauty.Tests
   ```

## Những thứ cần có để cài

- **.NET SDK 8.0** trở lên
- **Visual Studio 2022** (khuyến nghị) hoặc VS Code có cài extension C#
- **SQL Server** (SQL Server Express/Developer, hoặc LocalDB đi kèm Visual Studio) + **SQL Server Management Studio (SSMS)** để quản lý DB
- **Git** để clone và quản lý mã nguồn
- **Entity Framework Core Tools** (`dotnet-ef`) để chạy migration:
  ```bash
  dotnet tool install --global dotnet-ef
  ```
- Kết nối Internet (để tải Google Fonts và các gói NuGet lần đầu)
