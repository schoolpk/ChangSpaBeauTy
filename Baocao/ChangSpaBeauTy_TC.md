**BỘ GIÁO DỤC VÀ ĐÀO TẠO**

**TRƯỜNG ĐẠI HỌC TRƯNG VƯƠNG**

**![A logo for a university  AI-generated content may be incorrect.](data:image/png;base64...)**

**KHOA CÔNG NGHỆ THÔNG TIN**

**HỌC PHẦN : ĐẢM BẢO CHẤT LƯỢNG PHẦN MỀM**

**BÁO CÁO :**

**KIỂM THỬ – CHANGSPABEAUTY**

**Ứng dụng Web Shop Mỹ Phẩm & Spa Trực Tuyến**

**Giảng viên : Ths.Vi Mạnh Hùng**

**Sinh viên thực hiện:**

**Phạm Kế Trường** – CT230048

**Lò Quang Huy** – CT230017

Lớp: CT12302

Học Kỳ: 3 – Năm học : 2025-2026

**MỤC LỤC**

[Chương 1: Tổng quan về dự án và Yêu cầu chất lượng 4](#_Toc234692376)

[1.1. Giới thiệu đề tài 4](#_Toc234692377)

[1.2. Mô tả bài toán và chức năng 4](#_Toc234692378)

[1.3. Mục tiêu & Phạm vi kiểm thử 7](#_Toc234692379)

[Chương 2: Kế hoạch Đảm bảo chất & Kiểm thử 11](#_Toc234692380)

[2.1. Quy trình kiểm soát chất lượng và hoạt động rà soát 11](#_Toc234692381)

[2.2. Ba cách tiếp cận chính trong kiểm thử 12](#_Toc234692382)

[2.3. Môi trường thực hiện và các công cụ hỗ trợ 13](#_Toc234692383)

[2.4. Điều kiện kết thúc hoạt động kiểm thử 14](#_Toc234692384)

[Chương 3: Thiết kế Kiểm thử & Kết quả Hoạt động 16](#_Toc234692385)

[3.1. Những phát hiện từ quá trình rà soát tài liệu và mã nguồn 16](#_Toc234692386)

[3.2. Xây dựng các kịch bản kiểm thử 17](#_Toc234692387)

[3.2.1 đăng kí tài khoản 20](#_Toc234692388)

[3.2.2 Đăng nhập hệ thống 22](#_Toc234692389)

[3.2.3 Đăng xuất hệ thống 24](#_Toc234692390)

[3.2.4 Xem danh sách sản phẩm 25](#_Toc234692391)

[3.2.5 Tìm kiếm và Lọc sản phẩm 26](#_Toc234692392)

[3.2.6 Xem chi tiết sản phẩm 28](#_Toc234692393)

[3.2.7 Thêm vào giỏ hàng 29](#_Toc234692394)

[3.2.8 Quản lý giỏ hàng 30](#_Toc234692395)

[3.2.9 Đạt hàng 32](#_Toc234692396)

[3.2.10 Xem đơn hàng của tôi 33](#_Toc234692397)

[3.2.11 Chỉnh sửa đơn hàng 34](#_Toc234692398)

[3.2.12 Hủy đơn hàng 35](#_Toc234692399)

[3.2.13 Quản lý danh mục 37](#_Toc234692400)

[3.2.14 Quản lý sản phẩm 38](#_Toc234692401)

[3.2.15 Quản lý đơn hàng 40](#_Toc234692402)

[3.2.16 Quản lý người dùng 41](#_Toc234692403)

[3.2.17 Thông báo 42](#_Toc234692404)

[3.2.18 Kiểm thử phi chức năng 44](#_Toc234692405)

[Chương 4: Thực thi Kiểm thử & Quản lý Lỗi 46](#_Toc234692406)

[4.1. Kết quả thực thi các ca kiểm thử 46](#_Toc234692407)

[4.2. Những lỗi phát hiện và cách quản lý 48](#_Toc234692408)

[Chương 5: Đánh giá & Kết luận 50](#_Toc234692409)

[5.1.Đánh giá chất lượng phần mềm 50](#_Toc234692410)

[5.2. Những gì nhóm đã đạt được 51](#_Toc234692411)

[5.3. Những hạn chế và hướng phát triển 52](#_Toc234692412)

[PHỤ LỤC – BẢNG CHÚ THÍCH THUẬT NGỮ TIẾNG ANH 61](#_Toc234692413)

# Chương 1: Tổng quan về dự án và Yêu cầu chất lượng

## 1.1. Giới thiệu đề tài

ChangSpaBeauTy là hệ thống thương mại điện tử bán mỹ phẩm/spa trực tuyến, được xây dựng theo mô hình Clean Architecture gồm 6 project. Hệ thống phục vụ 2 nhóm người dùng: khách hàng và quản trị viên, xác thực bằng Cookie Authentication + mật khẩu băm BCrypt.

Dự án được phát triển trên nền tảng ASP.NET Core MVC 8 với các công nghệ chính: Entity Framework Core 8, SQL Server, NUnit 4.2.2 cho kiểm thử đơn vị, và Moq cho mocking. Hệ thống được tổ chức theo kiến trúc phân lớp với các tầng: Domain, Application, Infrastructure, Web, Api và Tests, bảo đảm sự tách biệt trách nhiệm và dễ bảo trì.

Báo cáo kiểm thử này tập trung vào việc đánh giá chất lượng của hệ thống thông qua các hoạt động kiểm thử tĩnh và kiểm thử động ở các cấp độ Unit Test và kiểm thử tích hợp/thủ công trên giao diện.

## 1.2. Mô tả bài toán và chức năng

Sơ đồ chức năng usecase:

![A diagram of a person's relationship  AI-generated content may be incorrect.](data:image/png;base64...)

*Sơ đồ 1.2: Sơ đồ usecase*

Các luồng nghiệp vụ chính cần kiểm thử:

Hệ thống ChangSpaBeauTy vận hành xoay quanh một hành trình mua sắm hoàn chỉnh, bắt đầu từ khi người dùng tiếp cận cửa hàng trực tuyến cho đến khi đơn hàng được hoàn tất. Hành trình này có thể được hình dung như một dòng chảy liên tục, với các điểm rẽ nhánh tùy theo vai trò của người dùng và trạng thái của đơn hàng.

Giải thích chi tiết các nhóm luồng nghiệp vụ**:** Hệ thống được chia thành bốn luồng nghiệp vụ chính, mỗi nhóm đảm nhiệm một giai đoạn trong hành trình mua sắm và vận hành cửa hàng trực tuyến.

Luồng truy cập và duyệt sản phẩm: đây là luồng dành cho tất cả người dùng, kể cả khách truy cập chưa đăng nhập. Luồng này bắt đầu khi người dùng mở trang chủ và có thể thực hiện các thao tác: xem danh sách sản phẩm nổi bật, tìm kiếm theo từ khóa, lọc theo danh mục hoặc thương hiệu, và xem chi tiết từng sản phẩm. Điểm đặc biệt của luồng này là không yêu cầu xác thực và không thay đổi dữ liệu hay nói cách khác người dùng chỉ đọc thông tin, không ghi gì vào hệ thống.

Luồng xác thực và quản lý giỏ hàng: đây là luồng bắt đầu khi người dùng muốn thực hiện giao dịch mua hàng. Luồng này bao gồm hai phần chính:

Phần xác thực: Người dùng đăng ký tài khoản mới hoặc đăng nhập vào hệ thống. Khi đăng ký, hệ thống phải kiểm tra email chưa được sử dụng, mã hóa mật khẩu bằng BCrypt trước khi lưu. Khi đăng nhập, hệ thống xác thực email và mật khẩu, sau đó tạo một phiên đăng nhập với các thông tin đặc tính của người dùng, bao gồm cả vai trò.

Phần quản lý giỏ hàng: Sau khi đăng nhập, người dùng có thể thêm sản phẩm vào giỏ, cập nhật số lượng, hoặc xóa sản phẩm khỏi giỏ. Điểm kiểm soát quan trọng nhất ở luồng này là kiểm tra tồn kho: mỗi lần thêm hoặc cập nhật số lượng, hệ thống phải đảm bảo số lượng mới không vượt quá số lượng tồn kho thực tế. Nếu sản phẩm đã có trong giỏ, số lượng mới sẽ được cộng dồn vào số lượng cũ.

Luồng đặt hàng và xử lý đơn: đây là luồng nghiệp vụ quan trọng nhất, nơi diễn ra giao dịch thực tế. Khi người dùng chuyển từ giỏ hàng sang trang đặt hàng, họ nhập địa chỉ giao hàng và số điện thoại, sau đó nhấn nút đặt hàng.

Toàn bộ quá trình đặt hàng được thực hiện trong một giao dịch cơ sở dữ liệu: nghĩa là nếu bất kỳ bước nào thất bại, tất cả các thay đổi sẽ bị hủy bỏ và dữ liệu trở về trạng thái ban đầu. Các bước cụ thể bao gồm: kiểm tra tồn kho lần cuối cho từng sản phẩm trong giỏ; tạo bản ghi đơn hàng mới với trạng thái chờ xác nhận; tạo các bản ghi chi tiết đơn hàng cho từng sản phẩm trừ số lượng tồn kho và cộng số lượng đã bán; xóa toàn bộ giỏ hàng; và gửi thông báo cho quản trị viên về đơn hàng mới.

Luồng theo dõi và xử lý đơn hàng: sau khi đơn hàng được tạo, nó bước vào một vòng đời với các trạng thái lần lượt là chờ xác nhận → đã xác nhận → đang giao → hoàn thành. Mỗi lần chuyển trạng thái, hệ thống sẽ gửi thông báo cho khách hàng để họ biết tình trạng đơn hàng của mình.

Người dùng có thể theo dõi lịch sử đơn hàng của mình, lọc theo từng trạng thái. Khi đơn hàng còn ở trạng thái chờ xác nhận hoặc đã xác nhận, khách hàng có thể hủy đơn và khi đó hệ thống sẽ hoàn trả tồn kho và giảm số lượng đã bán cho từng sản phẩm trong đơn hàng đó.

Khi đơn hàng đã ở trạng thái đang giao hoặc hoàn thành, khách hàng không thể hủy đơn vì điều này bảo đảm quy trình vận chuyển diễn ra suôn sẻ và không bị gián đoạn. Khách hàng cũng có thể chỉnh sửa thông tin đơn hàng như: địa chỉ, số điện thoại, số lượng sản phẩm khi đơn hàng còn ở trạng thái chờ xác nhận và khi thay đổi số lượng, hệ thống phải kiểm tra lại tồn kho để đảm bảo số lượng mới không vượt quá hàng hiện có.

Luồng quản trị dành cho Admin: bên cạnh bốn nhóm luồng chính cho người dùng, hệ thống còn có một luồng riêng dành cho quản trị viên để vận hành cửa hàng. Luồng này bao gồm ba nhóm chức năng:

Quản lý sản phẩm: thêm mới sản phẩm, sửa thông tin, tải ảnh lên, cập nhật tồn kho, và xóa sản phẩm. Khi xóa sản phẩm, Admin phải kiểm tra xem sản phẩm đã từng xuất hiện trong đơn hàng nào chưa, nếu có cần cân nhắc giữa việc giữ lại lịch sử đơn hàng và việc xóa sản phẩm.

Quản lý danh mục: thêm danh mục mới, sửa tên danh mục, và xóa danh mục. Danh mục chỉ có thể bị xóa khi không còn sản phẩm nào thuộc về nó.

Quản lý đơn hàng: xem danh sách tất cả đơn hàng, lọc theo trạng thái, cập nhật trạng thái đơn hàng (xác nhận, giao hàng, hoàn thành), và hủy đơn hàng kèm hoàn trả tồn kho.

Quản lý người dùng: có thể đôi vai trò của từng tài khoản người dùng. Người dùng chỉ có thể bị xóa khi trong giỏ của họ không có sản phẩm.

Mỗi thao tác quản trị đều được bảo vệ bởi cơ chế phân quyền, chỉ Admin mới có thể truy cập và thực hiện.

## 1.3. Mục tiêu & Phạm vi kiểm thử

**1.3.1. Mục tiêu kiểm thử**

Hoạt động kiểm thử trong dự án ChangSpaBeauTy được thực hiện nhằm đạt được các mục tiêu cụ thể sau:

Xác minh rằng tất cả các chức năng của hệ thống hoạt động đúng theo yêu cầu đã được phân tích ở Chương 3 của Mã nguồn mở. Điều này có nghĩa là mỗi tính năng từ đăng ký tài khoản, tìm kiếm sản phẩm, quản lý giỏ hàng, đặt hàng, cho đến quản trị cửa hàng đều phải hoạt động như mong đợi trong các tình huống khác nhau ngay cả khi người dùng thao tác đúng và khi họ cố tình nhập sai hoặc thực hiện các hành vi bất thường.

Bảo đảm tính nhất quán và toàn vẹn của dữ liệu, đặc biệt là đối với các nghiệp vụ liên quan đến tồn kho và đơn hàng. Khi một khách hàng đặt hàng thành công, số lượng tồn kho phải được trừ đi đúng số lượng đã bán, số lượng đã bán phải được cập nhật, và giỏ hàng của họ phải được xóa sạch. Nếu một đơn hàng bị hủy, tồn kho phải được hoàn trả chính xác về trạng thái ban đầu.

Phát hiện các lỗi tiềm ẩn trong mã nguồn và giao diện trước khi sản phẩm được bàn giao. Bằng cách thực hiện kiểm thử một cách có hệ thống, nhóm có thể xác định và ghi nhận các vấn đề cần khắc phục, từ đó cải thiện chất lượng tổng thể của sản phẩm trước khi người dùng cuối sử dụng.

Đánh giá chất lượng của hệ thống dựa trên các tiêu chí cụ thể, từ đó đưa ra quyết định về việc sản phẩm có đủ điều kiện để bàn giao hay chưa. Quá trình kiểm thử không chỉ dừng lại ở việc tìm lỗi, mà còn cung cấp một bức tranh tổng thể về mức độ sẵn sàng của sản phẩm.

Rèn luyện kỹ năng kiểm thử và áp dụng các kỹ thuật kiểm thử chuyên nghiệp như phân vùng tương đương, phân tích giá trị biên, và bảng quyết định, qua đó nâng cao năng lực của nhóm phát triển trong việc bảo đảm chất lượng phần mềm.

**1.3.2. Phạm vi kiểm thử**

Kiểm thử đơn vị: đây là cấp độ kiểm thử đầu tiên và cơ bản nhất, tập trung vào việc kiểm tra các logic nghiệp vụ thuần túy. Đây những đoạn mã không phụ thuộc vào cơ sở dữ liệu hay giao diện người dùng. Toàn bộ kiểm thử đơn vị được thực hiện tự động bằng NUnit và Moq trong dự án kiểm thử, với 20 test case được thiết kế để bao phủ bốn nhóm chức năng chính:

Xác thực và người dùng: kiểm tra việc xác thực email hợp lệ, mã hóa và xác thực mật khẩu bằng BCrypt, và các quy tắc đăng ký cơ bản.

Sản phẩm: kiểm tra các quy tắc lọc, tìm kiếm, sắp xếp sản phẩm, và tính toán phần trăm tồn kho.

Giỏ hàng: kiểm tra các quy tắc thêm vào giỏ, cập nhật số lượng, giới hạn số lượng theo tồn kho, và tính tổng tiền.

Đơn hàng: kiểm tra các quy tắc hủy đơn theo trạng thái, tính tổng tiền đơn hàng, và hiển thị nhãn trạng thái.

Kiểm thử tích hợp và kiểm thử hệ thống: ở cấp độ này, các chức năng được kiểm thử trong môi trường hoạt động thực tế, với kết nối đến cơ sở dữ liệu thật và tương tác đầy đủ giữa các tầng trong kiến trúc. Hình thức kiểm thử này được thực hiện thủ công trên giao diện web. Tổng cộng có 117 test case được thiết kế, phân bố như sau:

Nhóm Xác thực:21 test case kiểm tra đăng ký, đăng nhập và đăng xuất, bao gồm cả các tình huống thành công và thất bại như email đã tồn tại, mật khẩu sai, và bỏ trống trường bắt buộc.

Nhóm Sản phẩm:17 test case kiểm tra việc xem danh sách, tìm kiếm, lọc theo danh mục/thương hiệu, sắp xếp, và xem chi tiết sản phẩm.

Nhóm Giỏ hàng:15 test case kiểm tra thêm vào giỏ, cập nhật số lượng, xóa sản phẩm, xóa toàn bộ giỏ, và tính tổng tiền.

Nhóm Đơn hàng**:** 23 test case kiểm tra đặt hàng, xem lịch sử đơn hàng, chỉnh sửa đơn hàng và hủy đơn.

Nhóm Quản trị: 28 test case kiểm tra quản lý danh mục, quản lý sản phẩm, quản lý đơn hàng và quản lý người dùng.

Nhóm Thông báo: 7 test case kiểm tra việc tạo thông báo khi có đơn hàng mới, khi Admin đổi trạng thái đơn, khi khách hàng hủy đơn, cũng như đánh dấu đã đọc và xóa thông báo.

Nhóm Phi chức năng: 6 test case kiểm tra bảo mật, hiệu năng, nhất quán dữ liệu, và khả năng sử dụng.

Kỹ thuật kiểm thử áp dụng: để thiết kế các test case, nhóm sử dụng các kỹ thuật kiểm thử hộp đen chuyên nghiệp. Kỹ thuật phân vùng tương đương được áp dụng để chia các giá trị đầu vào thành các nhóm có cùng hành vi mong đợi. Kỹ thuật bảng quyết định được áp dụng cho các nghiệp vụ phức tạp có nhiều điều kiện kết hợp, như việc xác định một đơn hàng có được phép hủy hay không.

**1.3.3. Ngoài phạm vi kiểm thử**

Kiểm thử bảo mật: hệ thống hiện đang sử dụng cơ chế bảo vệ mặc định của ASP.NET Core nhưng chưa có các bài kiểm thử cụ thể để đánh giá mức độ an toàn trước các kỹ thuật tấn công phức tạp.

Kiểm thử hiệu năng và chịu tải: hệ thống sẽ không được kiểm thử về khả năng xử lý khi có số lượng lớn người dùng đồng thời hoặc khi bị tấn công từ chối dịch vụ. Những hoạt động này đòi hỏi công cụ chuyên dụng và kịch bản phức tạp, vượt quá phạm vi học thuật của đồ án.

Kiểm thử tự động hóa giao diện: các công cụ tự động hóa kiểm thử giao diện như Selenium hay Playwright sẽ không được triển khai. Toàn bộ kiểm thử ở cấp độ tích hợp và hệ thống sẽ được thực hiện thủ công, dẫn đến việc kiểm thử hồi quy sẽ tốn nhiều thời gian hơn nếu hệ thống thay đổi sau này.

Kiểm thử tương thích đa trình duyệt và đa thiết bị: hệ thống sẽ chỉ được kiểm thử trên hai trình duyệt phổ biến nhất như: Google Chrome và Microsoft Edge, và trên màn hình máy tính để bàn, với một số kiểm thử cơ bản trên kích thước màn hình di động. Các trình duyệt khác như: Firefox, Safari hay các thiết bị khác tablet, điện thoại Android/iOS đa dạng sẽ không được bao phủ.

Module API: Dự án API hiện mới chỉ ở dạng khung mẫu, chưa triển khai các nghiệp vụ thực tế của hệ thống. Do đó, việc kiểm thử API không nằm trong phạm vi của báo cáo này.

# Chương 2: Kế hoạch Đảm bảo chất & Kiểm thử

## 2.1. Quy trình kiểm soát chất lượng và hoạt động rà soát

Trước khi bắt tay vào viết mã hay thực hiện kiểm thử, nhóm phát triển đã thống nhất một quy trình rà soát chặt chẽ nhằm phát hiện sớm các sai sót từ khâu lên ý tưởng cho đến khi hoàn thiện sản phẩm. Quy trình này giống như một "bộ lọc" nhiều tầng, mỗi tầng sẽ phát hiện và loại bỏ những vấn đề tiềm ẩn trước khi chúng kịp len lỏi vào mã nguồn chính thức.

Bước đầu tiên trong quy trình này là rà soát đặc tả chức năng. Cả nhóm cùng ngồi lại, đọc kỹ từng dòng mô tả nghiệp vụ, đối chiếu với yêu cầu thực tế của cửa hàng mỹ phẩm ChangSpaBeauTy. Mục đích của bước này là bảo đảm rằng tất cả thành viên đều hiểu đúng và thống nhất về những gì hệ thống cần làm, tránh tình trạng mỗi người hiểu một kiểu dẫn đến sản phẩm cuối cùng không khớp với mong đợi. Chẳng hạn, khi thảo luận về chức năng hủy đơn hàng, nhóm đã phải làm rõ: khách hàng có thể hủy đơn ở những trạng thái nào? Admin có thể hủy đơn ở những trạng thái nào? Những câu hỏi tưởng chừng đơn giản nhưng nếu không được giải đáp ngay từ đầu sẽ gây ra những tranh cãi và sai sót về sau.

Bước tiếp theo là rà soát thiết kế cơ sở dữ liệu. Đây là công việc của trưởng nhóm cùng với thành viên phụ trách phần backend. Họ kiểm tra các bảng, mối quan hệ giữa các bảng, các khóa ngoại, và các ràng buộc dữ liệu những thứ sẽ là "nền móng" cho toàn bộ hệ thống. Một sai sót nhỏ ở tầng cơ sở dữ liệu cũng có thể kéo theo hàng loạt lỗi ở các tầng phía trên, giống như một tòa nhà xây trên nền móng yếu sẽ dễ dàng đổ sập khi có tác động.

Sau khi đã có thiết kế, nhóm tiến hành rà soát mã nguồn theo từng tầng trong kiến trúc Clean Architecture, từ tầng nơi chứa các thực thể cốt lõi cho đến tầng giao diện người dùng. Công việc này được thực hiện theo hình thức các thành viên đọc chéo mã nguồn của nhau trước khi hợp nhất vào nhánh chính. Điều này giống như việc có một người bạn đồng hành cùng bạn kiểm tra lại từng dòng chữ trước khi gửi đi, giúp phát hiện những lỗi mà chính tác giả có thể đã bỏ qua do quá quen thuộc với mã nguồn của mình.

Cuối cùng, các ca kiểm thử cũng được rà soát trước khi thực thi. Người phụ trách kiểm thử sẽ xem xét từng kịch bản, đảm bảo rằng chúng bao phủ đầy đủ các tình huống, cả thông thường lẫn ngoại lệ và các bước thực hiện được mô tả rõ ràng, dễ hiểu.

Để quá trình rà soát đạt hiệu quả cao, nhóm đã xây dựng một bảng kiểm tra như một "kim chỉ nam" cho từng hoạt động. Khi rà soát mã nguồn, các thành viên sẽ lần lượt kiểm tra: tên biến và tên hàm có rõ nghĩa, tuân thủ quy ước của ngôn ngữ C# hay không có kiểm tra đối tượng null trước khi thao tác để tránh lỗi sập ứng dụng hay không; nghiệp vụ tồn kho có được xử lý nhất quán theo cả hai chiều hay không; các thao tác ghi dữ liệu có được bảo vệ bởi cơ chế chống giả mạo yêu cầu hay không; thông báo lỗi hiển thị cho người dùng có rõ ràng và bằng tiếng Việt dễ hiểu không; và quan trọng nhất, có còn sót lại các dòng lệnh debug trong mã nguồn sản phẩm hay không.

Nhờ có quy trình rà soát nhiều tầng này, nhóm đã phát hiện được 6 điểm bất hợp lý ngay từ giai đoạn tĩnh, trước khi chúng kịp trở thành những lỗi thực sự trong quá trình kiểm thử động. Việc này giúp tiết kiệm rất nhiều thời gian và công sức.

## 2.2. Ba cách tiếp cận chính trong kiểm thử

Để bảo đảm chất lượng của hệ thống, nhóm áp dụng một chiến lược kiểm thử đa chiều, kết hợp cả ba góc nhìn: nhìn từ bên trong (hộp trắng), nhìn từ bên ngoài (hộp đen), và nhìn vừa trong vừa ngoài (hộp xám). Mỗi cách tiếp cận đóng một vai trò riêng, bổ sung cho nhau để tạo nên một bức tranh toàn diện về chất lượng phần mềm.

Cách tiếp cận hộp trắng: được áp dụng cho các kiểm thử đơn vị tự động trong dự án thử nghiện. Đây là cách kiểm thử mà người thực hiện nhìn thấy toàn bộ cấu trúc bên trong của mã nguồn, giống như một bác sĩ phẫu thuật nhìn thấy rõ từng cơ quan, mạch máu trước khi tiến hành ca mổ. Nhóm sử dụng NUnit và Moq để kiểm tra từng nhánh điều kiện (if/else) trong các lớp logic. Cụ thể, họ kiểm tra xem khi một điều kiện đúng thì nhánh xử lý tương ứng có chạy đúng không, và khi điều kiện sai thì nhánh khác có hoạt động như mong đợi không. Cách tiếp cận này giúp bảo đảm rằng mọi ngõ ngách trong mã nguồn đều được kiểm tra, không bỏ sót bất kỳ nhánh xử lý nào dù là nhỏ nhất.

Cách tiếp cận hộp đen: được áp dụng cho các kiểm thử thủ công trên giao diện web. Khác với hộp trắng, ở đây người kiểm thử không cần biết bên trong mã nguồn hoạt động thế nào, họ chỉ quan tâm đến đầu vào và đầu ra. Các kịch bản kiểm thử bao gồm: nhập thông tin đăng ký và kiểm tra xem tài khoản có được tạo không; thêm sản phẩm vào giỏ và kiểm tra xem số lượng có được cập nhật không; nhấn nút đặt hàng và kiểm tra xem đơn hàng có được tạo không. Cách tiếp cận này mô phỏng chính xác hành vi của người dùng thực tế, giúp phát hiện các lỗi về giao diện và trải nghiệm người dùng.

Cách tiếp cận hộp xám: là sự kết hợp hài hòa giữa hai phương pháp trên. Người kiểm thử có hiểu biết nhất định về cấu trúc bên trong nhưng vẫn tập trung vào kiểm thử chức năng từ góc nhìn người dùng. Họ có thể thiết kế các ca kiểm thử sát với thực tế hơn, chẳng hạn như kiểm tra xem sau khi đặt hàng thành công, tồn kho có thực sự bị trừ hay không, và Admin có nhận được thông báo hay không. Cách tiếp cận này tận dụng được ưu điểm của cả hai phương pháp: vừa hiểu được cách hệ thống vận hành bên trong, vừa kiểm thử từ góc độ người dùng cuối.

## 2.3. Môi trường thực hiện và các công cụ hỗ trợ

Môi trường kiểm thử được thiết lập như một "phòng thí nghiệm" riêng biệt, nơi các ca kiểm thử được thực hiện một cách có kiểm soát và lặp lại. Về phần cứng, các máy tính sử dụng hệ điều hành Windows 10 hoặc 11, với trình duyệt Google Chrome và Microsoft Edge làm công cụ tương tác chính, đây là hai trình duyệt phổ biến nhất mà người dùng cuối sẽ sử dụng, nên kiểm thử trên chúng giúp phát hiện các vấn đề tương thích sớm nhất.

Về phần mềm, toàn bộ hệ thống chạy trên nền tảng .NET 8.0, với cơ sở dữ liệu SQL Server, hoạt động như một "bản sao thu nhỏ" của hệ thống dữ liệu thật, cho phép nhóm kiểm thử thao tác mà không lo ảnh hưởng đến dữ liệu sản xuất. Các công cụ kiểm thử đơn vị bao gồm NUnit 4.2.2, một khung kiểm thử mạnh mẽ và linh hoạt, đi kèm với NUnit3TestAdapter và Microsoft.NET.Test.Sdk để tích hợp liền mạch với Visual Studio. Để mô phỏng các đối tượng phụ thuộc, nhóm sử dụng Moq 4.20.72, một công cụ tạo đối tượng giả, giúp kiểm thử các lớp logic mà không cần kết nối đến cơ sở dữ liệu thật, giúp các test chạy nhanh hơn và ổn định hơn.

Việc quản lý lỗi được thực hiện thông qua các file md thủ công, ghi lại chi tiết từng lỗi phát hiện, mức độ nghiêm trọng và trạng thái xử lý. Tuy chưa tích hợp với các hệ thống quản lý lỗi chuyên nghiệp như Jira, cách làm này vẫn đáp ứng được nhu cầu của một dự án học thuật. Các lệnh thử nghiệm được sử dụng để chạy toàn bộ bộ kiểm thử tự động, và kết quả được xuất ra các file TestResult.trx và TestReport.md để dễ dàng theo dõi và báo cáo.

## 2.4. Điều kiện kết thúc hoạt động kiểm thử

Kiểm thử cần có một "vạch đích" rõ ràng để xác định khi nào công việc kiểm thử đã hoàn tất và sản phẩm có thể được xem xét để bàn giao. Nhóm đã thống nhất bốn tiêu chí để xác định thời điểm dừng kiểm thử, giống như một chiếc la bàn chỉ hướng cho toàn bộ quá trình.

Tiêu chí đầu tiên và cơ bản nhất là tất cả các ca kiểm thử đã được thiết kế phải được thực thi đầy đủ. Mọi kịch bản đã được vạch ra đều đã được kiểm tra thực tế trên hệ thống. Tiêu chí này bảo đảm rằng không có góc nào của hệ thống bị bỏ qua.

Tiêu chí thứ hai là 100% các kiểm thử đơn vị tự động (20 test case) phải đạt kết quả “Đạt”. Đây là những kiểm thử nền tảng, kiểm tra các quy tắc nghiệp vụ cốt lõi như mã hóa mật khẩu, kiểm tra tồn kho, tính tổng tiền giỏ hàng, những thứ mà nếu sai sót sẽ gây hậu quả nghiêm trọng cho toàn bộ hệ thống. Việc yêu cầu 100% Pass là để bảo đảm rằng “nền móng” của hệ thống thực sự vững chắc.

Tiêu chí thứ ba là không còn lỗi nào ở mức nghiêm trọng hoặc quan trọng ở trạng thái chưa xử lý. Các lỗi ở mức này thường làm hỏng luồng chính của hệ thống hoặc gây sai lệch dữ liệu nghiêm trọng, và việc để chúng tồn tại sẽ ảnh hưởng đến uy tín của sản phẩm cũng như trải nghiệm của người dùng.

Tiêu chí thứ tư là tỷ lệ đạt bao gồm cả Unit Test và test case thủ công, phải đạt từ 90% trở lên. Con số này phản ánh chất lượng tổng thể của hệ thống: nếu tỷ lệ Pass cao có nghĩa là phần lớn các chức năng đều hoạt động đúng, và những lỗi còn lại chỉ nằm ở các trường hợp đặc biệt hoặc các module ít quan trọng hơn.

Khi tất cả các tiêu chí này được đáp ứng đồng thời, nhóm có thể tự tin kết luận rằng hệ thống đã sẵn sàng để xem xét bàn giao, và quá trình kiểm thử có thể chính thức kết thúc.

# Chương 3: Thiết kế Kiểm thử & Kết quả Hoạt động

## 3.1. Những phát hiện từ quá trình rà soát tài liệu và mã nguồn

Trước khi bắt tay vào kiểm thử chạy thực tế trên hệ thống, nhóm đã dành thời gian để quan xát kỹ từng trang tài liệu và từng dòng mã nguồn. Công việc này nếu có những vết xước nhỏ có thể không ảnh hưởng đến giá trị tổng thể, nhưng nếu có một vết nứt lớn, nó có thể làm hỏng cả sản phẩm.

Quá trình rà soát đã phát hiện ra 6 điểm bất hợp lý, được phân loại thành hai mức độ: những vấn đề nhỏ và những vấn đề quan trọng.

| **R** | **Vị trí** | **Vấn đề phát hiện** | **Mức độ** |
| --- | --- | --- | --- |
| R1 | ProductCreateViewModel.Stock | Thông báo lỗi "phải > 0" nhưng phạm vi cho phép giá trị = 0, gây nhập nhằng | Cấp độ nhỏ |
| R2 | AdminController.EditProduct | Form sửa sản phẩm không gán Thương hiệu vào model dẫn tới ô Thương hiệu bị trống dù DB đã có dữ liệu | Cấp độ lớn |
| R3 | OrderService.CancelOrderAsync | Còn sót Console.WriteLine debug trong code production | Cấp độ nhỏ |
| R4 | ProductService.DeleteProductAsync | Trừ Category.Total trước khi xóa sản phẩm → nếu xóa thất bại, số liệu bị sai lệch | Cấp độ lớn |
| R5 | Đặc tả nghiệp vụ | Không có tài liệu SRS mô tả rõ quy tắc chuyển trạng thái đơn hàng | Cấp độ nhỏ |
| R6 | CategoryCreateViewModel | Thương hiệu không có yêu cầu nhưng dịch vụ gọi .Trim() → nếu null sẽ ném lỗi | Cấp độ lớn |

*Bảng 3.1 – Tổng hợp các điểm bất hợp lý phát hiện qua rà soát*

Các vấn đề nhỏ thường là những lỗi về mặt hình thức hoặc thông báo chưa rõ ràng, không ảnh hưởng đến luồng chính của hệ thống nhưng vẫn cần được ghi nhận để cải thiện về sau. Chẳng hạn, trong lớp Mô hình tạo sản phẩm, thuộc tính số lượng có thông báo lỗi là "Số lượng phải > 0" nhưng lại cho phép giá trị bằng 0, gây nhập nhằng cho người dùng và lập trình viên.

Các vấn đề quan trọng mới là điều đáng quan tâm, vì chúng có thể gây ra những hệ lụy nghiêm trọng nếu không được xử lý. Điểm đầu tiên nằm ở Quản trị chỉnh sửa sản phẩm khi quản trị viên mở form sửa sản phẩm, trường Thương hiệu luôn bị trống, dù trong cơ sở dữ liệu sản phẩm đã có giá trị.

Điểm quan trọng thứ hai nằm ở Dịch vụ xóa sản phẩm đây là phương thức xóa sản phẩm này lại trừ Tổng số sản phẩm của danh mục trước khi thực sự xóa sản phẩm. Nếu quá trình xóa gặp lỗi giữa chừng, số liệu Tổng số sản phẩm của danh mục đã bị trừ nhưng sản phẩm vẫn tồn tại, dẫn đến dữ liệu tồn kho bị sai lệch vĩnh viễn.

Điểm quan trọng thứ ba liên quan đến Tạo mô hình theo danh mục thuộc tính Thương hiệu không được đánh dấu là bắt buộc, nhưng ở tầng Dịch vụ, phương thức Dịch vụ tạo danh mục lại gọi Danh mục.Trim() mà không kiểm tra trống. Nếu giá trị bị bỏ trống, hệ thống sẽ ném ra lỗi NullReferenceException giống như một chiếc máy được lập trình để vận hành nhưng lại thiếu một bộ phận quan trọng, khiến nó đứng yên thay vì chạy.

Tổng kết lại, sau quá trình rà soát, nhóm ghi nhận 6 điểm bất hợp lý. Trong đó, 3 điểm ở mức cấp độ nhỏ không ảnh hưởng đến luồng chính nên được lưu lại để cải thiện sau, còn 3 điểm ở mức cấp độ lớn sẽ được chuyển vào danh sách lỗi và ưu tiên kiểm tra kỹ trong giai đoạn kiểm thử động.

## 3.2. Xây dựng các kịch bản kiểm thử

Sau khi đã có cái nhìn tổng quan về hệ thống và những điểm cần lưu ý từ quá trình rà soát, bước tiếp theo là thiết kế các ca kiểm thử cụ thể mô tả cách thức kiểm tra từng chức năng của hệ thống. Việc thiết kế ca kiểm thử cũng giống như một đạo diễn viết kịch bản cho một vở kịch: ông ta cần xác định nhân vật (người dùng), bối cảnh (trạng thái hệ thống), hành động (thao tác đầu vào), và kết cục mong đợi (kết quả đầu ra).

Để bảo đảm các ca kiểm thử bao phủ được mọi tình huống, nhóm áp dụng một số kỹ thuật thiết kế chuyên nghiệp. Kỹ thuật phân vùng tương đương giống như việc chia một đại lượng thành các nhóm có tính chất giống nhau, rồi chỉ cần kiểm tra một giá trị đại diện cho mỗi nhóm. Ví dụ, với trường Email, các giá trị hợp lệ (có @ và tên miền) thuộc một nhóm, các giá trị không hợp lệ (thiếu @, thiếu tên miền) thuộc một nhóm khác. Thay vì kiểm tra hàng trăm email khác nhau, nhóm chỉ cần kiểm tra một vài đại diện cho mỗi nhóm là đủ.

Kỹ thuật phân tích giá trị biên tập trung vào các "ranh giới" giá trị ở mép của vùng hợp lệ, nơi thường xảy ra lỗi nhất. Ví dụ, với quy tắc mật khẩu tối thiểu 6 ký tự, các giá trị biên sẽ là 5 ký tự (vừa dưới ngưỡng), 6 ký tự (đúng ngưỡng), và 7 ký tự (vừa trên ngưỡng). Tương tự, với số lượng tồn kho, các giá trị biên là 0 (hết hàng), 1 (còn ít), và một số lớn (còn nhiều). Những giá trị này thường là "điểm yếu" của hệ thống, nơi các lập trình viên dễ bỏ sót kiểm tra.

Kỹ thuật bảng quyết định được sử dụng cho các nghiệp vụ phức tạp có nhiều điều kiện kết hợp, như việc xác định một đơn hàng có được phép hủy hay không. Bảng quyết định giống như một ma trận, liệt kê tất cả các tổ hợp điều kiện có thể xảy ra và hành động tương ứng. Trong trường hợp hủy đơn, các điều kiện bao gồm trạng thái hiện tại của đơn hàng và vai trò của người yêu cầu. Bằng cách kết hợp các điều kiện này, nhóm có thể thiết kế các ca kiểm thử bao phủ mọi tình huống từ đó việc hủy đơn thành công cho đến việc bị từ chối một cách hợp lý.

Kỹ thuật hộp trắng được áp dụng khi viết các Unit Test tự động. Thay vì chỉ nhìn từ bên ngoài, các lập trình viên nhìn vào bên trong mã nguồn để xác định các nhánh điều kiện và viết test để kiểm tra từng nhánh.

Từ những kỹ thuật này, nhóm đã thiết kế được bộ test case với tổng cộng 117 ca kiểm thử, bao phủ 17 nhóm chức năng (F01 đến F17) và 6 nhóm yêu cầu phi chức năng (NFR).

| **Nhóm chức năng** | **Mô tả ngắn** | **Số ca kiểm thử** |
| --- | --- | --- |
| F01 | Đăng ký tài khoản (Khách truy cập) | 10 |
| F02 | Đăng nhập hệ thống | 8 |
| F03 | Đăng xuất | 3 |
| F04 | Xem danh sách sản phẩm | 4 |
| F05 | Tìm kiếm & lọc sản phẩm | 9 |
| F06 | Xem chi tiết sản phẩm | 4 |
| F07 | Thêm vào giỏ hàng (Customer) | 8 |
| F08 | Quản lý giỏ hàng (Customer) | 7 |
| F09 | Đặt hàng (Customer) | 7 |
| F10 | Xem đơn hàng của tôi (Customer) | 4 |
| F11 | Chỉnh sửa đơn hàng (Customer) | 6 |
| F12 | Hủy đơn hàng (Customer) | 6 |
| F13 | Quản lý danh mục (Admin) | 8 |
| F14 | Quản lý sản phẩm (Admin) | 8 |
| F15 | Quản lý đơn hàng (Admin) | 7 |
| F16 | Quản lý người dùng (Admin) | 5 |
| F17 | Thông báo (Customer, Admin) | 7 |
| NFR | Phi chức năng (Bảo mật, Hiệu năng, Nhất quán dữ liệu) | 6 |
| TỔNG CỘNG |  | 117 |

*Bảng 3.2 – Tổng hợp số lượng test case theo nhóm chức năng*

Mỗi ca kiểm thử đều được gán một mã định danh duy nhất, chỉ rõ ưu tiên, kỹ thuật áp dụng, điều kiện tiên quyết, dữ liệu đầu vào, và kết quả mong đợi. Bộ test case này đóng vai trò như một "bản đồ chi tiết", chỉ dẫn cho người kiểm thử biết cần làm gì, làm như thế nào, và kết quả ra sao.

### 3.2.1 đăng kí tài khoản

Mục tiêu kiểm thử F01: Nhóm test case này tập trung kiểm tra quy trình đăng ký tài khoản mới trong những cửa ngõ đầu tiên của hệ thống. Mục tiêu là bảo đảm người dùng có thể tạo tài khoản một cách dễ dàng khi dữ liệu hợp lệ, trong khi các trường hợp bất thường bị chặn đúng cách. Các test case được thiết kế để kiểm tra từng trường dữ liệu một cách độc lập, từ đó xác định chính xác điểm yếu của form đăng ký. Ngoài ra, nhóm còn kiểm tra khía cạnh bảo mật như mã hóa mật khẩu và chống tấn công XSS/SQL Injection.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 1 | TC\_F01\_01 | Đăng ký thành công với dữ liệu hợp lệ | Chưa có tài khoản với email dùng để test | Nhập Họ tên, Email, Mật khẩu, SĐT, Địa chỉ hợp lệ. Nhấn Đăng ký. | Tài khoản được tạo; mật khẩu được mã hóa BCrypt; thông báo thành công và chuyển sang trang đăng nhập |
| 2 | TC\_F01\_02 | Từ chối đăng ký khi email đã tồn tại | Email “truong@gmail.com” đã tồn tại | Nhập lại Email này cùng các thông tin khác hợp lệ | Hệ thống từ chối, hiển thị "Email đã được sử dụng" |
| 3 | TC\_F01\_03 | Từ chối email sai định dạng | Không cần điều kiện đặc biệt | Nhập Email thiếu @, thiếu tên miền, hoặc có ký tự đặc biệt sai vị trí | Bị từ chối tại bước validate, hiển thị thông báo định dạng email không hợp lệ |
| 4 | TC\_F01\_04 | Kiểm tra ràng buộc độ dài mật khẩu tối thiểu (6 ký tự) | Email dùng để test chưa tồn tại | Nhập Mật khẩu lần lượt 5, 6, 7 ký tự | 5 ký tự bị từ chối; 6 và 7 ký tự được chấp nhận |
| 5 | TC\_F01\_05 | Từ chối khi bỏ trống các trường bắt buộc | Không cần điều kiện đặc biệt | Để trống từng trường một (Họ tên, Email, Mật khẩu, SĐT, Địa chỉ) | Hệ thống từ chối, hiển thị thông báo "bắt buộc nhập" tương ứng |
| 6 | TC\_F01\_06 | Mật khẩu được mã hóa trước khi lưu vào CSDL | Đăng ký thành công một tài khoản mới | Kiểm tra giá trị cột Password trong bảng Users | Giá trị là chuỗi băm BCrypt (dạng "$2a$..."), không phải văn bản thuần |
| 7 | TC\_F01\_07 | Từ chối số điện thoại sai định dạng | Không cần điều kiện đặc biệt | Nhập SĐT chứa chữ, quá ngắn, hoặc quá dài | Hệ thống từ chối hoặc cảnh báo định dạng số điện thoại không hợp lệ |
| 8 | TC\_F01\_08 | Email có khoảng trắng đầu/cuối được xử lý đúng | Không cần điều kiện đặc biệt | Nhập Email có khoảng trắng đầu/cuối | Hệ thống tự động loại bỏ khoảng trắng (trim) trước khi lưu/so sánh |
| 9 | TC\_F01\_09 | Họ tên chứa tiếng Việt có dấu và ký tự hợp lệ | Không cần điều kiện đặc biệt | Nhập Họ tên tiếng Việt có dấu | Đăng ký thành công, tên được lưu và hiển thị đúng, không lỗi encoding |
| 10 | TC\_F01\_10 | Chống SQL Injection / XSS ở form đăng ký | Không cần điều kiện đặc biệt | Nhập script hoặc câu lệnh SQL độc hại | Hệ thống không thực thi script, không gây lỗi CSDL; dữ liệu được hiển thị dạng văn bản thuần (đã escape) |

*Bảng 3.2.1 – Các ca kiểm thử tiêu biểu của nhóm F01*

### 3.2.2 Đăng nhập hệ thống

Mục tiêu kiểm thử F02: Nhóm test case này tập trung vào cổng đăng nhập nơi xác thực danh tính người dùng trước khi họ truy cập các chức năng được bảo vệ. Các test case được thiết kế để kiểm tra cả luồng thành công (đăng nhập với vai trò Customer và Admin) lẫn các trường hợp thất bại (email không tồn tại, sai mật khẩu, bỏ trống trường) và các tính năng đi kèm như "Ghi nhớ đăng nhập". Test case bảo mật chống SQL Injection cũng được đưa vào để đảm bảo cổng đăng nhập an toàn.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 11 | TC\_F02\_01 | Đăng nhập thành công với vai trò Customer | Tài khoản Customer đã tồn tại | Nhập đúng Email và Mật khẩu Customer | Đăng nhập thành công, điều hướng về trang chủ |
| 12 | TC\_F02\_02 | Đăng nhập thành công với vai trò Admin | Tài khoản Admin đã tồn tại | Nhập đúng Email/Mật khẩu Admin | Đăng nhập thành công, điều hướng đến trang quản trị (/Admin) |
| 13 | TC\_F02\_03 | Từ chối đăng nhập khi email không tồn tại | Email nhập vào chưa từng đăng ký | Nhập Email chưa đăng ký và Mật khẩu bất kỳ | Thông báo "Email không tồn tại", không tạo phiên đăng nhập |
| 14 | TC\_F02\_04 | Từ chối đăng nhập khi sai mật khẩu | Email tồn tại, mật khẩu nhập sai | Nhập đúng Email, Mật khẩu sai | Thông báo "Mật khẩu không đúng", không tạo phiên đăng nhập |
| 15 | TC\_F02\_05 | Ghi nhớ đăng nhập (Remember me) | Tài khoản hợp lệ | Đăng nhập với "Ghi nhớ đăng nhập" được chọn, đóng/mở lại trình duyệt | Vẫn duy trì trạng thái đã đăng nhập, không phải nhập lại |
| 16 | TC\_F02\_06 | Đăng nhập với Email khác chữ hoa/thường vẫn nhận diện đúng | Tài khoản đăng ký với email “Truong@gmail.com” | Đăng nhập với Email “truong@gmail.com”, Mật khẩu đúng | Hệ thống nhận diện đúng và cho đăng nhập thành công |
| 17 | TC\_F02\_07 | Bỏ trống Email hoặc Mật khẩu khi đăng nhập | Không cần điều kiện đặc biệt | Để trống Email (hoặc Mật khẩu) | Hệ thống yêu cầu nhập đầy đủ, không gửi request |
| 18 | TC\_F02\_08 | Chống SQL Injection tại form đăng nhập | Không cần điều kiện đặc biệt | Nhập Email="admin' OR '1'='1", Mật khẩu bất kỳ | Từ chối đăng nhập, không bị bypass xác thực |

*Bảng 3.2.2 – Các ca kiểm thử tiêu biểu của nhóm F02*

### 3.2.3 Đăng xuất hệ thống

Mục tiêu kiểm thử F03: Nhóm test case này tập trung kiểm tra quy trình đăng xuất, việc kết thúc phiên làm việc của người dùng một cách an toàn. Các test case bảo đảm cookie xác thực bị xóa, người dùng không thể truy cập vào các trang yêu cầu đăng nhập sau khi đăng xuất, và không thể dùng nút Back của trình duyệt để quay lại trang đã được bảo vệ.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 19 | TC\_F03\_01 | Đăng xuất xóa phiên làm việc | Đã đăng nhập thành công | Nhấn nút Đăng xuất | Cookie xác thực bị xóa, điều hướng về trang chủ ở trạng thái khách truy cập |
| 20 | TC\_F03\_02 | Không thể truy cập trang yêu cầu đăng nhập sau khi đăng xuất | Vừa thực hiện đăng xuất | Truy cập URL yêu cầu đăng nhập (ví dụ /Order/MyOrders) | Hệ thống chuyển hướng về trang Đăng nhập |
| 21 | TC\_F03\_03 | Dùng nút Back của trình duyệt sau khi đăng xuất | Vừa đăng xuất khỏi trang yêu cầu đăng nhập | Nhấn nút Back trên trình duyệt | Không hiển thị lại nội dung cache, yêu cầu đăng nhập lại |

*Bảng 3.2.3 – Các ca kiểm thử của nhóm F03*

### 3.2.4 Xem danh sách sản phẩm

Mục tiêu kiểm thử F04**:** Nhóm test case này kiểm tra khả năng hiển thị danh sách sản phẩm trên trang chủ và trang danh sách đầy đủ. Các test case bảo đảm dữ liệu hiển thị chính xác (phân loại đúng theo tiêu chí phổ biến/mới nhất/bán chạy), phân trang hoạt động đúng, và các trường hợp đặc biệt (danh mục rỗng, trang vượt quá số trang) được xử lý tốt mà không gây lỗi hệ thống.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 22 | TC\_F04\_01 | Trang chủ hiển thị đúng các nhóm sản phẩm | CSDL có sản phẩm với các mức Sold khác nhau | Truy cập trang chủ | Hiển thị đủ 3 khối: sản phẩm phổ biến, mới nhất, bán chạy; dữ liệu đúng tiêu chí |
| 23 | TC\_F04\_02 | Trang danh sách đầy đủ hiển thị hết sản phẩm | CSDL có nhiều hơn 1 trang sản phẩm | Truy cập trang Danh sách sản phẩm, chuyển qua các trang | Tất cả sản phẩm được liệt kê, không thiếu/trùng lặp |
| 24 | TC\_F04\_03 | Hiển thị khi danh mục không có sản phẩm nào | Có 1 danh mục chưa có sản phẩm | Lọc theo danh mục rỗng này | Hiển thị thông báo "Không có sản phẩm" hoặc danh sách rỗng, không lỗi |
| 25 | TC\_F04\_04 | Truy cập trang phân trang cuối cùng / vượt quá số trang | Danh sách sản phẩm có N trang | Truy cập trang N và trang N+1 | Trang N hiển thị đúng; trang N+1 hiển thị rỗng hoặc tự chuyển về trang hợp lệ |

*Bảng 3.2.4 – Các ca kiểm thử của nhóm F04*

### 3.2.5 Tìm kiếm và Lọc sản phẩm

Mục tiêu kiểm thử F05: Nhóm test case này kiểm tra tính năng tìm kiếm và lọc sản phẩm, một trong những chức năng được sử dụng nhiều nhất bởi người dùng. Các test case tập trung vào tính chính xác của kết quả tìm kiếm (không phân biệt hoa thường), hiệu quả của bộ lọc (danh mục, thương hiệu), sắp xếp (giá, mới nhất, bán chạy), và khả năng xử lý các trường hợp đặc biệt (từ khóa không tồn tại, kết hợp nhiều điều kiện, ký tự đặc biệt). Đặc biệt, test case bảo mật được đưa vào để kiểm tra khả năng chống tấn công XSS/SQL Injection qua ô tìm kiếm.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 26 | TC\_F05\_01 | Tìm kiếm theo từ khóa đúng tên sản phẩm | CSDL có sản phẩm tên chứa "Son" | Nhập từ khóa "Son" | Trả về danh sách sản phẩm có tên chứa "Son" |
| 27 | TC\_F05\_02 | Tìm kiếm không phân biệt hoa thường | CSDL có sản phẩm "Kem dưỡng ẩm" và "KEM chống nắng" | Nhập từ khóa "kem" (viết thường) | Trả về cả hai sản phẩm |
| 28 | TC\_F05\_03 | Lọc sản phẩm theo danh mục | CSDL có sản phẩm ở nhiều danh mục | Chọn danh mục "Dưỡng da mặt" | Chỉ trả về sản phẩm thuộc danh mục đã chọn |
| 29 | TC\_F05\_04 | Lọc sản phẩm theo thương hiệu | CSDL có sản phẩm gắn nhiều thương hiệu | Chọn một thương hiệu cụ thể | Chỉ hiển thị sản phẩm đúng thương hiệu |
| 30 | TC\_F05\_05 | Sắp xếp sản phẩm theo giá tăng dần / giảm dần | CSDL có sản phẩm với các mức giá khác nhau | Chọn "price-asc" và "price-desc" | price-asc: giá thấp nhất đầu tiên; price-desc: giá cao nhất đầu tiên |
| 31 | TC\_F05\_06 | Tìm kiếm với từ khóa không tồn tại | Từ khóa không khớp bất kỳ sản phẩm nào | Nhập từ khóa không tồn tại | Danh sách rỗng, thông báo "không tìm thấy sản phẩm" |
| 32 | TC\_F05\_07 | Kết hợp đồng thời nhiều điều kiện lọc | CSDL đủ dữ liệu kiểm tra tổ hợp | Danh mục + Thương hiệu + Sắp xếp | Kết quả thỏa mãn cả 3 điều kiện |
| 33 | TC\_F05\_08 | Ô tìm kiếm để trống | Không cần điều kiện đặc biệt | Để trống ô tìm kiếm, nhấn Tìm kiếm | Trả về toàn bộ danh sách sản phẩm (không lọc) |
| 34 | TC\_F05\_09 | Tìm kiếm với ký tự đặc biệt/mã script | Không cần điều kiện đặc biệt | Nhập script hoặc câu lệnh SQL độc hại | Xử lý an toàn, trả về rỗng, không thực thi script |

*Bảng 3.2.5 – Các ca kiểm thử tiêu biểu của nhóm F05*

### 3.2.6 Xem chi tiết sản phẩm

Mục tiêu kiểm thử F06: Nhóm test case này kiểm tra trang chi tiết sản phẩm, nơi người dùng xem thông tin đầy đủ trước khi quyết định mua. Các test case bảo đảm hiển thị đầy đủ các trường thông tin (tên, giá, ảnh, mô tả, tồn kho, danh mục, thương hiệu), xử lý đúng khi sản phẩm không tồn tại (trả về 404), và hiển thị trạng thái "Hết hàng" khi Stock=0. Ngoài ra, kiểm tra việc hiển thị ảnh mặc định khi sản phẩm chưa có ảnh để tránh lỗi giao diện.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 35 | TC\_F06\_01 | Xem chi tiết sản phẩm tồn tại | Sản phẩm có ProductId hợp lệ | Truy cập trang chi tiết sản phẩm | Hiển thị đầy đủ tên, giá, ảnh, mô tả, tồn kho, danh mục, thương hiệu |
| 36 | TC\_F06\_02 | Truy cập chi tiết sản phẩm không tồn tại | ProductId không tồn tại | Truy cập URL với id không tồn tại | Trang lỗi/404 hoặc thông báo "Sản phẩm không tồn tại" |
| 37 | TC\_F06\_03 | Xem chi tiết sản phẩm đã hết hàng (Stock=0) | Sản phẩm có Stock=0 | Truy cập trang chi tiết sản phẩm | Nút "Thêm vào giỏ"/"Mua ngay" bị vô hiệu hóa hoặc hiển thị "Hết hàng" |
| 38 | TC\_F06\_04 | Hiển thị ảnh mặc định khi sản phẩm không có ảnh | Sản phẩm có Image rỗng/null | Truy cập trang chi tiết | Hiển thị ảnh mặc định (placeholder), không hiển thị ảnh vỡ |

*Bảng 3.2.6 – Các ca kiểm thử của nhóm F06*

### 3.2.7 Thêm vào giỏ hàng

Mục tiêu kiểm thử F07: Nhóm test case này kiểm tra chức năng thêm sản phẩm vào giỏ, nghiệp vụ quan trọng bậc nhất của hệ thống thương mại điện tử. Các test case tập trung vào kiểm soát tồn kho (không cho thêm khi hết hàng hoặc vượt quá tồn kho), cộng dồn số lượng khi sản phẩm đã có trong giỏ, và bảo vệ chống thao tác khi chưa đăng nhập. Ngoài ra, kiểm tra các trường hợp biên như thêm đúng bằng số lượng tồn kho, thêm với số lượng 0 hoặc số âm.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 39 | TC\_F07\_01 | Thêm sản phẩm còn hàng vào giỏ thành công | Đã đăng nhập, sản phẩm A có Stock=10 | Thêm 3 sản phẩm A | Giỏ có 1 dòng với số lượng 3; thông báo thành công |
| 40 | TC\_F07\_02 | Từ chối thêm sản phẩm đã hết hàng | Sản phẩm B có Stock=0 | Nhấn "Thêm vào giỏ" sản phẩm B | Từ chối, thông báo "Sản phẩm đã hết hàng" |
| 41 | TC\_F07\_03 | Từ chối khi số lượng thêm vượt tồn kho | Sản phẩm C Stock=50 | Nhập số lượng 100 | Từ chối, thông báo "chỉ còn 50 trong kho" |
| 42 | TC\_F07\_04 | Cộng dồn số lượng khi sản phẩm đã có trong giỏ | Sản phẩm D Stock=20; giỏ đã có 4 | Thêm tiếp 3 sản phẩm D | Số lượng cập nhật thành 7 (cộng dồn) |
| 43 | TC\_F07\_05 | Thêm đúng bằng số lượng tồn kho còn lại | Sản phẩm E Stock=5 | Nhập số lượng 5 | Thêm thành công, giỏ có 5 sản phẩm E |
| 44 | TC\_F07\_06 | Từ chối khi tổng số lượng trong giỏ + thêm mới vượt tồn kho | Sản phẩm F Stock=5; giỏ đã có 4 | Thêm tiếp 3 sản phẩm F | Từ chối, thông báo còn 5 trong kho |
| 45 | TC\_F07\_07 | Chặn thêm vào giỏ khi chưa đăng nhập | Chưa đăng nhập | Nhấn "Thêm vào giỏ" | Chuyển hướng đến trang Đăng nhập |
| 46 | TC\_F07\_08 | Từ chối thêm với số lượng = 0 hoặc số âm | Sản phẩm G còn hàng | Nhập số lượng 0 hoặc -1 | Từ chối hoặc tự động điều chỉnh về tối thiểu 1 |

*Bảng 3.2.7 – Các ca kiểm thử tiêu biểu của nhóm F07*

### 3.2.8 Quản lý giỏ hàng

Mục tiêu kiểm thử F08: Nhóm test case này kiểm tra các thao tác quản lý giỏ hàng sau khi đã có sản phẩm: cập nhật số lượng (bao gồm tự động giới hạn khi vượt tồn kho), xóa từng sản phẩm (khi số lượng ≤ 0 hoặc nhấn nút xóa), xóa toàn bộ giỏ, và tính tổng tiền. Test case bảo mật IDOR (Insecure Direct Object Reference) được đưa vào để đảm bảo người dùng không thể thao tác lên CartItem của người khác.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 47 | TC\_F08\_01 | Cập nhật số lượng hợp lệ trong giỏ | Giỏ có sản phẩm A Stock=10, SL=2 | Sửa số lượng thành 5 | Cập nhật thành 5; tổng tiền tính lại chính xác |
| 48 | TC\_F08\_02 | Tự động giới hạn (clamp) khi cập nhật vượt tồn kho | Sản phẩm B Stock=10 | Sửa số lượng thành 99 | Tự động giảm về 10 (đúng tồn kho) |
| 49 | TC\_F08\_03 | Xóa sản phẩm khỏi giỏ khi số lượng ≤ 0 | Sản phẩm C đang có trong giỏ | Sửa số lượng thành 0 | Dòng sản phẩm C bị xóa |
| 50 | TC\_F08\_04 | Xóa từng sản phẩm khỏi giỏ | Giỏ có ít nhất 2 sản phẩm | Nhấn Xóa trên 1 dòng | Chỉ sản phẩm được chọn bị xóa |
| 51 | TC\_F08\_05 | Xóa toàn bộ giỏ hàng | Giỏ có nhiều sản phẩm | Nhấn "Xóa toàn bộ giỏ hàng" | Giỏ trống hoàn toàn; badge hiển thị 0 |
| 52 | TC\_F08\_06 | Tính đúng tổng tiền giỏ hàng (GrandTotal) | Giỏ có nhiều sản phẩm | Thêm (200k×2) + (150k×1) | Tổng = 550.000đ |
| 53 | TC\_F08\_07 | Chặn thao tác lên CartItem không thuộc tài khoản hiện tại (IDOR) | Biết CartItemId thuộc giỏ của người khác | Gửi request cập nhật/xóa đến CartItemId đó | Từ chối hoặc không tìm thấy item; giỏ hàng của người khác không bị ảnh hưởng |

*Bảng 3.2.8 – Các ca kiểm thử tiêu biểu của nhóm F08*

### 3.2.9 Đạt hàng

Mục tiêu kiểm thử F09: Nhóm test case này kiểm tra quy trình đặt hàng, nghiệp vụ cốt lõi của hệ thống thương mại điện tử. Các test case tập trung vào kiểm soát tồn kho lần cuối (không cho đặt khi giỏ rỗng hoặc tồn kho không đủ), tính tổng tiền chính xác, xóa giỏ sau khi đặt thành công, và gửi thông báo cho Admin. Đặc biệt, test case về giao dịch cơ sở dữ liệu đảm bảo tính nguyên tử (atomic): nếu bất kỳ bước nào thất bại, toàn bộ thay đổi được hoàn tác. Test case về xử lý đồng thời kiểm tra tình huống hai người dùng cùng đặt sản phẩm cuối cùng.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 54 | TC\_F09\_01 | Đặt hàng thành công với giỏ hàng hợp lệ | Giỏ có sản phẩm với số lượng ≤ tồn kho | Nhập Địa chỉ, SĐT; nhấn Đặt hàng | Tạo đơn pending; trừ tồn kho, cộng Sold; xóa giỏ; gửi thông báo Admin |
| 55 | TC\_F09\_02 | Từ chối đặt hàng khi giỏ hàng rỗng | Giỏ không có sản phẩm | Truy cập trang Đặt hàng hoặc gọi API | Từ chối, báo lỗi "Không có sản phẩm" |
| 56 | TC\_F09\_03 | Từ chối đặt hàng khi tồn kho không đủ tại thời điểm đặt | Giỏ có SL=5 nhưng tồn kho còn 2 | Tiến hành Đặt hàng | Từ chối, thông báo "chỉ còn 2 trong kho" |
| 57 | TC\_F09\_04 | Tính đúng tổng tiền đơn hàng khi đặt | Giỏ có (300k×2) + (150k×1) | Đặt hàng thành công | TotalPrice = 750.000đ |
| 58 | TC\_F09\_05 | Từ chối khi bỏ trống Địa chỉ hoặc SĐT | Giỏ hợp lệ, có sản phẩm | Để trống Địa chỉ hoặc SĐT | Yêu cầu nhập đầy đủ thông tin |
| 59 | TC\_F09\_06 | Chặn đặt hàng khi chưa đăng nhập | Chưa đăng nhập | Truy cập URL trang Đặt hàng | Chuyển hướng đến trang Đăng nhập |
| 60 | TC\_F09\_07 | Hai người dùng cùng đặt sản phẩm cuối cùng gần như đồng thời | Sản phẩm H Stock=1; hai tài khoản cùng có H trong giỏ | Hai tài khoản gần như đồng thời nhấn Đặt hàng | Chỉ 1 đơn thành công; đơn còn lại bị từ chối do hết hàng |

*Bảng 3.2.9 – Các ca kiểm thử tiêu biểu của nhóm F09*

### 3.2.10 Xem đơn hàng của tôi

Mục tiêu kiểm thử F10: Nhóm test case này kiểm tra trang lịch sử đơn hàng của khách hàng, bảo đảm chỉ hiển thị đúng đơn của người dùng hiện tại (không lẫn đơn của người khác). Hỗ trợ lọc theo trạng thái, hiển thị thông báo phù hợp khi chưa có đơn hàng, và bảo vệ khỏi việc xem chi tiết đơn của người khác qua URL (IDOR).

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 61 | TC\_F10\_01 | Hiển thị đúng danh sách đơn hàng của người dùng hiện tại | Tài khoản A có 2 đơn, tài khoản B có 1 đơn | Đăng nhập A, truy cập "Đơn hàng của tôi" | Chỉ hiển thị 2 đơn của A |
| 62 | TC\_F10\_02 | Lọc danh sách đơn hàng theo trạng thái | Tài khoản có đơn ở nhiều trạng thái | Chọn lọc "Chờ xác nhận" | Chỉ hiển thị đơn pending |
| 63 | TC\_F10\_03 | Hiển thị khi tài khoản chưa có đơn hàng nào | Tài khoản mới chưa đặt hàng | Truy cập "Đơn hàng của tôi" | Hiển thị "Bạn chưa có đơn hàng nào" hoặc danh sách rỗng |
| 64 | TC\_F10\_04 | Chặn xem chi tiết đơn hàng của người khác (IDOR) | Biết OrderId thuộc tài khoản B | Truy cập URL xem chi tiết đơn đó | Từ chối hoặc "Không tìm thấy đơn hàng" |

*Bảng 3.2.10 – Các ca kiểm thử của nhóm F10*

### 3.2.11 Chỉnh sửa đơn hàng

Mục tiêu kiểm thử F11: Nhóm test case này kiểm tra chức năng chỉnh sửa đơn hàng, cho phép khách hàng thay đổi thông tin đơn khi còn ở trạng thái pending. Các test case tập trung vào kiểm soát tồn kho khi thay đổi số lượng (hoàn trả tồn kho cũ, kiểm tra tồn kho mới), và bảo vệ chỉ cho phép sửa khi đơn ở đúng trạng thái. Ngoài ra, kiểm tra việc từ chối khi đơn còn 0 sản phẩm và bảo vệ IDOR.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 65 | TC\_F11\_01 | Sửa đơn hàng thành công khi đang ở pending | Đơn #X pending, sản phẩm còn đủ tồn kho | Đổi Địa chỉ, SĐT, tăng số lượng 1 sản phẩm | Cập nhật thành công; tồn kho hoàn/trừ đúng; TotalPrice tính lại |
| 66 | TC\_F11\_02 | Từ chối sửa đơn khi không còn ở pending | Đơn #Y đã chuyển sang confirmed/shipping/done | Truy cập sửa đơn #Y, thay đổi và Lưu | Từ chối, thông báo "Chỉ có thể sửa đơn khi đang chờ xác nhận" |
| 67 | TC\_F11\_03 | Từ chối khi sửa đơn còn 0 sản phẩm | Đơn #Z pending, đang có 1 sản phẩm | Xóa hết sản phẩm khỏi đơn, Lưu | Từ chối, thông báo "Đơn hàng phải có ít nhất 1 sản phẩm" |
| 68 | TC\_F11\_04 | Từ chối khi sửa số lượng vượt tồn kho hiện có | Đơn pending có sản phẩm A; tồn kho khả dụng = 5 | Sửa số lượng thành 10 (>5) | Từ chối, thông báo "chỉ còn 5 trong kho" |
| 69 | TC\_F11\_05 | Giảm số lượng sản phẩm trong đơn hàng khi sửa | Đơn pending có A SL=5; tồn kho hiện tại = 3 | Sửa SL từ 5 xuống 2 | Cập nhật thành công; tồn kho tăng ròng 3; TotalPrice giảm |
| 70 | TC\_F11\_06 | Chặn sửa đơn hàng của người khác (IDOR) | Biết OrderId thuộc tài khoản B pending | Truy cập sửa đơn với OrderId đó | Từ chối, "Không tìm thấy đơn hàng" |

*Bảng 3.2.11 – Các ca kiểm thử của nhóm F11*

### 3.2.12 Hủy đơn hàng

Mục tiêu kiểm thử F12: Nhóm test case này kiểm tra chức năng hủy đơn hàng, một trong những quy tắc nghiệp vụ phức tạp nhất, yêu cầu kiểm soát chặt chẽ trạng thái và hoàn trả tồn kho chính xác. Các test case bảo đảm chỉ cho phép hủy ở các trạng thái cho phép (pending, confirmed), và không cho hủy ở shipping, done, hoặc đã hủy (tránh cộng trùng tồn kho). Kiểm tra hoàn trả tồn kho và giảm Sold khi hủy thành công, cũng như bảo vệ IDOR.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 71 | TC\_F12\_01 | Hủy thành công đơn hàng ở pending | Đơn #A pending | Nhấn "Hủy đơn hàng", Xác nhận | Chuyển cancelled; hoàn trả tồn kho; giảm Sold; gửi thông báo Admin |
| 72 | TC\_F12\_02 | Hủy thành công đơn hàng ở confirmed | Đơn #B confirmed | Nhấn "Hủy đơn hàng" | Được hủy thành công (do quy tắc chỉ chặn shipping/done) |
| 73 | TC\_F12\_03 | Từ chối hủy đơn hàng đang giao (shipping) | Đơn #C shipping | Nhấn "Hủy đơn hàng" | Từ chối, thông báo "Không thể hủy đơn khi đang giao hoặc đã hoàn thành" |
| 74 | TC\_F12\_04 | Từ chối hủy đơn hàng đã hoàn thành (done) | Đơn #D done | Nhấn "Hủy đơn hàng" | Từ chối với cùng thông báo |
| 75 | TC\_F12\_05 | Từ chối hủy đơn hàng đã bị hủy trước đó | Đơn #E cancelled | Gọi lại chức năng hủy | Từ chối, thông báo "Đơn hàng đã bị hủy trước đó"; không hoàn kho thêm |
| 76 | TC\_F12\_06 | Chặn hủy đơn hàng của người khác (IDOR) | Biết OrderId thuộc tài khoản B pending | Gửi yêu cầu hủy với OrderId đó | Từ chối, "Không có đơn hàng nào" |

*Bảng 3.2.12 – Các ca kiểm thử của nhóm F12*

### 3.2.13 Quản lý danh mục

Mục tiêu kiểm thử F13: Nhóm test case này kiểm tra chức năng quản lý danh mục của Admin, bao gồm thêm, sửa, xóa danh mục với các ràng buộc về tên trùng và sản phẩm liên kết. Các test case bảo đảm tính toàn vẹn dữ liệu: không cho thêm trùng tên, không cho xóa danh mục còn sản phẩm, và không cho gỡ thương hiệu đang được sản phẩm sử dụng. Kiểm tra cả trường hợp để trống tên và ID không tồn tại.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 77 | TC\_F13\_01 | Thêm danh mục mới thành công | Tên "Nước hoa" chưa tồn tại | Nhập Tên="Nước hoa", Lưu | Thêm thành công; xuất hiện trong danh sách |
| 78 | TC\_F13\_02 | Từ chối thêm danh mục trùng tên | Danh mục "Nước hoa" đã tồn tại | Nhập lại Tên="Nước hoa" | Từ chối, thông báo "Đã tồn tại" |
| 79 | TC\_F13\_03 | Từ chối đổi tên danh mục trùng với danh mục khác | Có 2 danh mục: "Trang điểm" và "Chăm sóc cơ thể" | Sửa "Chăm sóc cơ thể" thành "Trang điểm" | Từ chối, thông báo "Tên đã được dùng bởi danh mục khác" |
| 80 | TC\_F13\_04 | Xóa thành công danh mục không còn sản phẩm | Danh mục "Test" không có sản phẩm | Nhấn Xóa | Xóa thành công |
| 81 | TC\_F13\_05 | Từ chối xóa danh mục còn sản phẩm | Danh mục "Dưỡng da mặt" có sản phẩm | Nhấn Xóa | Từ chối, thông báo "Không thể xóa: danh mục đang có N sản phẩm" |
| 82 | TC\_F13\_06 | Từ chối gỡ thương hiệu đang được sản phẩm sử dụng | Danh mục có trademark đang được sản phẩm dùng | Xóa trademark đó khỏi danh mục, Lưu | Từ chối, liệt kê sản phẩm bị ảnh hưởng |
| 83 | TC\_F13\_07 | Từ chối thêm danh mục khi để trống Tên | Không cần điều kiện | Để trống Tên, nhập Trademark | Yêu cầu nhập Tên, không tạo bản ghi |
| 84 | TC\_F13\_08 | Xóa/sửa danh mục với Id không tồn tại | Id không tồn tại | Gửi request với id=99999 | Trả về "Không tìm thấy danh mục", không lỗi 500 |

*Bảng 3.2.13 – Các ca kiểm thử của nhóm F13*

### 3.2.14 Quản lý sản phẩm

Mục tiêu kiểm thử F14: Nhóm test case này kiểm tra chức năng quản lý sản phẩm của Admin — bao gồm thêm, sửa, xóa sản phẩm, upload ảnh, và các ràng buộc dữ liệu. Test case đặc biệt (TC\_F14\_04) cảnh báo về tính toàn vẹn khi xóa sản phẩm đã có trong đơn hàng — cần đối chiếu với hành vi thực tế để xác định đây là lỗi hay hành vi mong muốn. Kiểm tra cả định dạng ảnh không hợp lệ, giá/tồn kho âm, và để trống tên.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 85 | TC\_F14\_01 | Thêm sản phẩm mới thành công | Danh mục hợp lệ | Nhập đầy đủ thông tin, tải ảnh | Thêm thành công; Total danh mục tăng 1; thương hiệu mới được đồng bộ |
| 86 | TC\_F14\_02 | Sửa thông tin sản phẩm thành công | Sản phẩm đã tồn tại | Sửa Giá và Tồn kho | Cập nhật thành công; ảnh cũ giữ nguyên |
| 87 | TC\_F14\_03 | Xóa sản phẩm chưa từng được đặt hàng | Sản phẩm mới tạo | Nhấn Xóa, Xác nhận | Xóa thành công; Total danh mục giảm 1; ảnh vật lý bị xóa |
| 88 | TC\_F14\_04 | Xóa sản phẩm đã từng xuất hiện trong đơn hàng | Sản phẩm đã có OrderDetail | Nhấn Xóa, Xác nhận | Kỳ vọng: từ chối hoặc cảnh báo; Cần đối chiếu thực tế: theo mã nguồn hiện tại có thể xóa luôn OrderDetail, nguy cơ sai lệch lịch sử đơn hàng |
| 89 | TC\_F14\_05 | Tải ảnh sản phẩm định dạng không hợp lệ | Không có điều kiện | Chọn file .txt hoặc .exe | Từ chối, yêu cầu đúng định dạng ảnh |
| 90 | TC\_F14\_06 | Từ chối/khuyến cáo khi nhập Giá hoặc Tồn kho số âm | Không có điều kiện | Nhập Giá=-100000 hoặc Tồn kho=-5 | Từ chối hoặc yêu cầu giá trị ≥ 0 |
| 91 | TC\_F14\_07 | Từ chối khi để trống Tên sản phẩm | Không có điều kiện | Để trống Tên, nhập các trường khác | Yêu cầu nhập Tên |
| 92 | TC\_F14\_08 | Nhập Giá = 0 | Không có điều kiện | Nhập Giá=0 | Xử lý nhất quán: từ chối hoặc chấp nhận rõ ràng là khuyến mãi |

*Bảng 3.2.14 – Các ca kiểm thử của nhóm F14*

### 3.2.15 Quản lý đơn hàng

Mục tiêu kiểm thử F15: Nhóm test case này kiểm tra chức năng quản lý đơn hàng của Admin, bao gồm xem danh sách và lọc theo trạng thái, cập nhật trạng thái theo luồng (pending → confirmed → shipping → done), và hủy đơn kèm hoàn trả tồn kho. Các test case bảo đảm Admin không thể cập nhật với giá trị trạng thái không hợp lệ, không hủy đơn 2 lần (tránh cộng trùng tồn kho), và thống kê trên Dashboard chính xác. Kiểm tra phân quyền: Customer không thể truy cập trang Admin.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 93 | TC\_F15\_01 | Xem và lọc danh sách đơn hàng theo trạng thái | Có đơn ở nhiều trạng thái | Chọn lọc "shipping" | Chỉ hiển thị đơn shipping |
| 94 | TC\_F15\_02 | Cập nhật trạng thái đơn hàng theo đúng luồng | Đơn #X pending | Cập nhật: pending→confirmed→shipping→done | Mỗi bước thành công; gửi thông báo cho khách hàng |
| 95 | TC\_F15\_03 | Admin chuyển trạng thái đơn hàng sang "cancelled" | Đơn #Y confirmed | Cập nhật thành "cancelled" | Chuyển cancelled; hoàn trả tồn kho; giảm Sold; gửi thông báo |
| 96 | TC\_F15\_04 | Từ chối cập nhật với giá trị trạng thái không hợp lệ | Đơn #Z tồn tại | Gửi status="shipped123" | Từ chối, thông báo "Trạng thái không hợp lệ" |
| 97 | TC\_F15\_05 | Hủy đơn 2 lần liên tiếp không được cộng trùng tồn kho | Đơn #W đã cancelled | Admin thực hiện lại chuyển sang cancelled | Không cộng thêm tồn kho lần thứ 2 |
| 98 | TC\_F15\_06 | Thống kê trên Dashboard | Có sẵn dữ liệu đơn hàng | Truy cập Dashboard Admin | Số liệu khớp với CSDL; đơn cancelled không tính vào tổng đơn hợp lệ |
| 99 | TC\_F15\_07 | Chặn Customer truy cập trang quản trị | Đăng nhập Customer | Truy cập URL /Admin | Từ chối truy cập (403/redirect) |

*Bảng 3.2.15 – Các ca kiểm thử của nhóm F15*

### 3.2.16 Quản lý người dùng

Mục tiêu kiểm thử F16: Nhóm test case này kiểm tra chức năng quản lý người dùng của Admin, bao gồm xem danh sách, đổi vai trò Customer ↔ Admin, và xóa tài khoản kèm dữ liệu liên quan. Test case đặc biệt (TC\_F16\_03) kiểm tra lỗ hổng CSRF (Cross-Site Request Forgery) vì theo review mã nguồn, action DeleteUser hiện không có [ValidateAntiForgeryToken]. Cần xác nhận nếu tái hiện được và ghi nhận vào Bug Log. Kiểm tra cả trường hợp Admin tự đổi vai trò của chính mình.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 100 | TC\_F16\_01 | Đổi vai trò Customer → Admin và ngược lại | Tài khoản U Role=Customer | Nhấn "Đổi vai trò" | Chuyển thành Admin; nhấn lại chuyển về Customer |
| 101 | TC\_F16\_02 | Xóa tài khoản người dùng | Tài khoản U có dữ liệu liên quan | Nhấn Xóa, Xác nhận | Tài khoản bị xóa; ghi nhận cách xử lý dữ liệu liên quan |
| 102 | TC\_F16\_03 | Chống CSRF khi đổi vai trò/xóa người dùng | Đã đăng nhập Admin | Gửi request không có Anti-Forgery Token | Kỳ vọng: từ chối; Theo review mã nguồn, DeleteUser chưa có [ValidateAntiForgeryToken] → có thể là lỗ hổng CSRF |
| 103 | TC\_F16\_04 | Xem danh sách toàn bộ người dùng | Có nhiều tài khoản | Truy cập Quản lý người dùng | Hiển thị đầy đủ danh sách kèm vai trò |
| 104 | TC\_F16\_05 | Admin tự đổi vai trò của chính mình về Customer | Chỉ có 1 Admin, đang đăng nhập | Admin nhấn "Đổi vai trò" trên chính mình | Nên cảnh báo hoặc chặn để tránh mất Admin cuối cùng |

*Bảng 3.2.16 – Các ca kiểm thử của nhóm F16*

### 3.2.17 Thông báo

Mục tiêu kiểm thử F17: Nhóm test case này kiểm tra hệ thống thông báo, một chức năng quan trọng giúp giữ liên lạc giữa khách hàng và Admin. Các test case bảo đảm thông báo được tạo đúng lúc (khi đặt hàng mới, khi đổi trạng thái, khi hủy đơn), được gửi đúng người nhận (Admin khi có đơn mới, Customer khi đổi trạng thái), và có thể quản lý (đánh dấu đã đọc, xóa). Kiểm tra hiển thị thời gian tạo chính xác và trường hợp không có thông báo.

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 105 | TC\_F17\_01 | Tạo thông báo cho Admin khi có đơn hàng mới | Có tài khoản Admin | Khách hàng đặt hàng thành công | Thông báo mới xuất hiện trong danh sách của Admin |
| 106 | TC\_F17\_02 | Tạo thông báo cho khách hàng khi Admin đổi trạng thái đơn | Đơn #X thuộc khách K | Admin cập nhật trạng thái #X | Khách K nhận thông báo nội dung phù hợp |
| 107 | TC\_F17\_03 | Tạo thông báo khi khách hàng hủy đơn | Có tài khoản Admin | Khách hàng hủy đơn pending | Admin nhận thông báo có tên khách, mã đơn, giá trị |
| 108 | TC\_F17\_04 | Đánh dấu thông báo đã đọc | Có ít nhất 1 thông báo chưa đọc | Nhấn vào thông báo | Chuyển đã đọc; badge giảm |
| 109 | TC\_F17\_05 | Xóa toàn bộ thông báo | Có nhiều thông báo | Nhấn "Xóa tất cả" | Danh sách trống hoàn toàn |
| 110 | TC\_F17\_06 | Thông báo hiển thị đúng thời gian tạo | Vừa phát sinh thông báo mới | Quan sát nhãn thời gian | Hiển thị "vừa xong"/"X phút trước", đúng múi giờ |
| 111 | TC\_F17\_07 | Hiển thị khi không có thông báo nào | Tài khoản chưa từng nhận thông báo | Truy cập mục Thông báo | Hiển thị "Không có thông báo nào" |

*Bảng 3.2.17 – Các ca kiểm thử của nhóm F17*

### 3.2.18 Kiểm thử phi chức năng

Mục tiêu kiểm thử NFR: Nhóm test case này kiểm tra các yêu cầu phi chức năng, những yếu tố quan trọng nhưng không phải là chức năng cụ thể, bao gồm bảo mật (mật khẩu không hiển thị dạng rõ, cookie có HttpOnly, phân quyền trang Admin), hiệu năng (thời gian tải trang danh sách sản phẩm với số lượng lớn), nhất quán dữ liệu (tổng Stock + Sold không đổi qua chu trình đặt hàng - hủy hàng), và khả năng sử dụng (giao diện responsive trên màn hình di động).

| **STT** | **Mã TC** | **Mục tiêu kiểm thử** | **Điều kiện tiên quyết** | **Dữ liệu đầu vào / Bước thực hiện** | **Kết quả mong đợi** |
| --- | --- | --- | --- | --- | --- |
| 112 | TC\_NFR\_01 | Mật khẩu không hiển thị dạng rõ ở bất kỳ đâu | Đã đăng nhập | Kiểm tra các trang Hồ sơ, Quản lý người dùng | Không hiển thị mật khẩu dạng văn bản thuần |
| 113 | TC\_NFR\_02 | Trang quản trị yêu cầu đăng nhập với vai trò Admin | Chưa đăng nhập hoặc Customer | Truy cập /Admin, /Admin/Products | Chuyển hướng về Đăng nhập hoặc 403 |
| 114 | TC\_NFR\_03 | Thời gian tải trang danh sách sản phẩm với số lượng lớn | CSDL có ≥ 200 sản phẩm | Truy cập trang Danh sách, đo thời gian | Dưới 3 giây (môi trường dev), không treo/timeout |
| 115 | TC\_NFR\_04 | Tổng Stock + Sold không đổi qua chu trình đặt-hủy | Sản phẩm A Stock=20, Sold=5 | Đặt 3 → Hủy đơn đó | Stock và Sold trở về ban đầu; tổng không đổi |
| 116 | TC\_NFR\_05 | Giao diện responsive trên màn hình di động | Không có điều kiện | Truy cập ở kích thước 375px | Giao diện co giãn hợp lý; không vỡ layout |
| 117 | TC\_NFR\_06 | Cookie xác thực có HttpOnly | Đã đăng nhập | Kiểm tra thuộc tính cookie | Có HttpOnly (và Secure nếu HTTPS) |

*Bảng 3.20 – Các ca kiểm thử của nhóm NFR*

# Chương 4: Thực thi Kiểm thử & Quản lý Lỗi

## 4.1. Kết quả thực thi các ca kiểm thử

Sau khi đã có bộ test case được thiết kế chi tiết, nhóm bắt tay vào giai đoạn thực thi — chạy thực tế từng ca kiểm thử trên hệ thống. Giai đoạn này giống như việc một phi công thực hiện các bài kiểm tra trên máy bay trước khi cất cánh: mọi công tắc, mọi nút bấm đều được kiểm tra kỹ lưỡng để bảo đảm máy bay an toàn khi bay.

Đầu tiên là các kiểm thử đơn vị tự động, được viết bằng NUnit và chạy tự động thông qua lệnh Dotnet test. Bộ kiểm thử này gồm 20 ca, chia thành 4 nhóm tương ứng với 4 module nghiệp vụ cốt lõi. Điều đáng mừng là tất cả 20 ca đều đạt kết quả "Đạt", đạt tỷ lệ thành công 100%. Điều này có nghĩa là các quy tắc nghiệp vụ cơ bản như mã hóa mật khẩu, kiểm tra tồn kho, tính tổng tiền giỏ hàng, và quản lý trạng thái đơn hàng đều hoạt động chính xác như mong đợi. Đây là một tín hiệu tích cực, cho thấy "nền móng" của hệ thống đã được xây dựng vững chắc. Thời gian chạy toàn bộ bộ test chỉ mất 0.34 giây, thể hiện hiệu năng tốt và cấu trúc mã nguồn sạch sẽ.

| **Nhóm** | **Số lượng TC** | **Pass** | **Fail** | **Tỷ lệ Pass** |
| --- | --- | --- | --- | --- |
| Auth / User | 5 | 5 | 0 | 100% |
| Product | 5 | 5 | 0 | 100% |
| Cart | 5 | 5 | 0 | 100% |
| Order | 5 | 5 | 0 | 100% |
| Tổng cộng | 20 | 20 | 0 | 100% |

*Bảng 4.1 – Kết quả Unit Test tự động*

*Framework: NUnit 4.2.2 , .NET 8.0, Thời gian chạy: 0.34s, Ngày chạy: 22/06/2026*

Sau đó là các kiểm thử thủ công trên giao diện, bao gồm 117 ca đã được thiết kế. Đây là phần kiểm thử chiếm nhiều thời gian nhất, vì mỗi ca đều cần được thực hiện từng bước một bằng tay, giống như người thợ thủ công tỉ mỉ kiểm tra từng sản phẩm trước khi đóng gói. Kết quả cho thấy 113 ca đạt và 4 ca thất bại, tương ứng với tỷ lệ Pass là 96.6%.

| **Module** | **Tổng TC thiết kế** | **Đã chạy** | **Đạt** | **Thất bại** | **Tỷ lệ Pass** |
| --- | --- | --- | --- | --- | --- |
| Auth | 10 | 10 | 10 | 0 | 100% |
| Product | 13 | 13 | 13 | 0 | 100% |
| Cart | 15 | 15 | 15 | 0 | 100% |
| Order | 19 | 19 | 17 | 2 | 89.5% |
| Admin | 21 | 21 | 19 | 2 | 90.5% |
| Notification | 7 | 7 | 7 | 0 | 100% |
| NFR | 6 | 6 | 6 | 0 | 100% |
| Tổng cộng | 117 | 117 | 113 | 4 | 96.6% |

*Bảng 4.2 – Kết quả Test Case thủ công theo module*

Nhìn vào các module cụ thể, các module Xác thực (Auth), Sản phẩm (Product), Giỏ hàng (Cart), Thông báo (Notification) và Phi chức năng (NFR) đều đạt 100%. Tất cả các ca kiểm thử thiết kế đều thành công, cho thấy các luồng chính của hệ thống hoạt động trơn tru. Module Đơn hàng (Order) đạt 89.5%, có 2 ca thất bại liên quan đến việc kiểm tra tồn kho khi chỉnh sửa đơn hàng và giao diện chưa có ràng buộc số lượng tối đa. Module Quản trị (Admin) đạt 90.5%, cũng có 2 ca thất bại liên quan đến lỗi không hiển thị thương hiệu khi sửa sản phẩm và sai thứ tự xóa sản phẩm ảnh hưởng đến thống kê danh mục.

Tính chung cả hai loại kiểm thử, tổng số ca kiểm thử là 137 (20 Unit Test + 117 thủ công). Số ca đạt là 133, số ca thất bại là 4, đạt tỷ lệ thành công 97.1%.

## 4.2. Những lỗi phát hiện và cách quản lý

Trong quá trình kiểm thử, nhóm đã ghi nhận và theo dõi tất cả các lỗi phát sinh thông qua một "nhật ký lỗi" (Bug Log). Đây giống như một cuốn sổ ghi chép của thám tử, nơi lỗi đều được mô tả chi tiết: module nào, mức độ nguy hiểm và tình trạng.

| **Bug ID** | **Tên lỗi** | **Test Case liên quan** | **Mô tả chi tiết** | **Mức độ** | **Trạng thái** |
| --- | --- | --- | --- | --- | --- |
| BUG-01 | Form sửa sản phẩm không hiển thị Trademark cũ | TC\_ADM\_04 | AdminController.EditProduct không gán vào ViewModel → ô Thương hiệu luôn trống | Cấp độ lớn | Mở |
| BUG-02 | Sai lệch Category.Total khi xóa sản phẩm thất bại giữa chừng | TC\_ADM\_04 | Trừ Category.Total trước khi xóa sản phẩm → nếu xóa thất bại, số liệu danh mục sai lệch | Cấp độ lớn | Mở |
| BUG-03 | Sửa đơn hàng không kiểm tra tồn kho real-time phía client | TC\_ORD\_07 | Giao diện EditOrder.cshtml không giới hạn theo Stock → chỉ báo lỗi sau khi submit | Cấp độ nhỏ | Mở |
| BUG-04 | Debug log còn sót trong code production | TC\_ORD\_01 | OrderService.CancelOrderAsync còn Consolu.Writeline(“[DEBUG]..”); | Cấp độ nhỏ | Mở |

*Bảng 4.3 – Danh sách lỗi phát hiện (Bug Log)*

Bốn lỗi đã được phát hiện, trong đó có hai lỗi ở mức "Cấp độ lớn" (quan trọng) và hai lỗi ở mức "Cấp độ nhẹ" (nhẹ).

Lỗi cấp độ lớn đầu tiên (BUG-01) liên quan đến form sửa sản phẩm: trường Thương hiệu bị trống khi mở form, dù dữ liệu đã có trong cơ sở dữ liệu. Lỗi này giống như khi bạn mở một tập tin để chỉnh sửa nhưng thấy nội dung bị mất bạn không biết mình đang sửa cái gì, và nếu lưu lại, bạn có thể vô tình làm mất dữ liệu cũ. Lỗi này xuất phát từ việc lập trình viên quên gán giá trị Thương hiệu sản phẩm vào Mô hình khi khởi tạo form.

Lỗi cấp độ lớn thứ hai (BUG-02) liên quan đến việc xóa sản phẩm. Hệ thống hiện đang thực hiện trừ Số lượng danh mục sản phẩm trước khi thực sự xóa sản phẩm, nếu quá trình xóa gặp lỗi, số liệu thống kê sẽ bị sai lệch vĩnh viễn. Đây là một vi phạm nghiêm trọng về tính toàn vẹn dữ liệu, giống như một người thủ kho ghi giảm số lượng hàng trong sổ nhưng chưa kịp lấy hàng ra khỏi kệ, dẫn đến sổ sách không khớp với thực tế.

Hai lỗi ở mức cấp độ nhẹ là BUG-03 (giao diện sửa đơn hàng chưa có ràng buộc số lượng tối đa theo tồn kho) và BUG-04 (còn sót dòng lệnh debug trong mã nguồn). Cả hai đều không ảnh hưởng đến luồng chính của hệ thống, nhưng cần được khắc phục để nâng cao chất lượng và tính chuyên nghiệp của sản phẩm.

Đối với các lỗi Cấp độ lớn, nhóm đã có minh chứng cụ thể: với BUG-01, khi Admin vào Quản lý sản phẩm → Sửa sản phẩm, trường Thương hiệu hiển thị rỗng thay vì hiển thị "LOREAL" như trong cơ sở dữ liệu. Lỗi này tái hiện được 100% mỗi khi thao tác lại. Với BUG-02, nhóm đã đối chiếu trình tự lệnh trong Dịch vụ xóa sản phẩm và xác định rằng việc cập nhật Số lượng danh mục sản phẩm diễn ra trước khi xóa sản phẩm thực sự, dẫn đến nguy cơ sai lệch dữ liệu.

Tất cả các lỗi đều đang ở trạng thái "Mở" (chưa xử lý) và sẽ được ưu tiên khắc phục trong giai đoạn tiếp theo của dự án.

# Chương 5: Đánh giá & Kết luận

## 5.1.Đánh giá chất lượng phần mềm

Sau khi hoàn thành toàn bộ quá trình kiểm thử, nhóm đã có một bức tranh rõ ràng về chất lượng hiện tại của hệ thống. Để đánh giá một cách khách quan, nhóm đã đối chiếu kết quả thực tế với các tiêu chí dừng kiểm thử đã đề ra từ đầu (ở Chương 2.4). Đây giống như việc so sánh điểm số của một học sinh với thang điểm đánh giá để xem em đó có đạt yêu cầu hay không.

| **Tiêu chí** | **Kết quả thực tế** | **Đạt?** |
| --- | --- | --- |
| 100% Test Case đã thiết kế được thực thi | 137/137 ca đã chạy (20 Unit + 117 thủ công) | ✅ |
| 100% Unit Test tự động Passed | 20/20 (100%) | ✅ |
| Không còn lỗi Critical/Major ở trạng thái Open | Còn 2 lỗi cấp độ lớn (BUG-01, BUG-02) chưa fix | ❌ |
| Tỷ lệ Pass tổng thể ≥ 90% | 97.1% (133/137) | ✅ |

*Bảng 5.1 – Đối chiếu kết quả với Tiêu chí dừng kiểm thử (Exit Criteria)*

Tiêu chí thứ nhất: 100% test case được thực thi, đã đạt được. Tất cả 137 ca kiểm thử (20 Unit Test + 117 thủ công) đều đã được chạy, không còn ca nào ở trạng thái "chưa chạy". Điều này bảo đảm rằng không có góc nào của hệ thống bị bỏ qua.

Tiêu chí thứ hai: 100% Unit Test tự động đạt "Passed" cũng đã đạt được. Cả 20 ca Unit Test đều thành công, chứng tỏ các quy tắc nghiệp vụ cốt lõi được cài đặt chính xác.

Tiêu chí thứ ba: không còn lỗi Critical/Major ở trạng thái Open: chưa đạt được. Hiện vẫn còn 2 lỗi Major (BUG-01 và BUG-02) chưa được khắc phục. Đây là điểm yếu nhất của hệ thống hiện tại, khiến nó chưa thể được bàn giao chính thức.

Tiêu chí thứ tư: tỷ lệ Pass tổng thể ≥ 90% đã đạt được với con số 97.1%. Điều này có nghĩa là phần lớn các chức năng đều hoạt động đúng, và những lỗi còn lại nằm ở các module ít quan trọng hơn.

Tổng kết lại, hệ thống đạt 3/4 tiêu chí dừng kiểm thử, nhưng chưa đạt tiêu chí về lỗi Major. Do đó, nhóm khuyến nghị chưa nên bàn giao hoặc phát hành chính thức cho đến khi hai lỗi Major này được khắc phục và kiểm thử hồi quy lại các ca liên quan. Tuy nhiên, xét về mặt logic nghiệp vụ cốt lõi (Xác thực, Giỏ hàng, Đặt hàng), hệ thống hoạt động ổn định và chính xác 100%, đây là những luồng quan trọng nhất đối với một hệ thống thương mại điện tử.

## 5.2. Những gì nhóm đã đạt được

Dù hệ thống vẫn còn một số hạn chế, nhóm đã đạt được nhiều thành tựu đáng ghi nhận, cả về mặt sản phẩm lẫn kỹ năng.

Về mặt sản phẩm, nhóm đã xây dựng hoàn chỉnh một hệ thống bán hàng full-stack theo kiến trúc Clean Architecture với 6 tầng rõ ràng. Bộ Unit Test tự động gồm 20 ca đạt 100% Pass, bao phủ 4 module nghiệp vụ cốt lõi. Bộ Test Case thủ công với 117 ca bao phủ 17 yêu cầu chức năng (F01-F17) và 6 yêu cầu phi chức năng, đã phát hiện 4 lỗi thực tế (2 Major, 2 Minor). Những con số này cho thấy quá trình kiểm thử được thực hiện nghiêm túc và có hệ thống.

Về mặt kỹ năng, nhóm đã thực hành trọn vẹn quy trình Đảm bảo chất lượng phần mềm (SQA): từ việc rà soát tài liệu và mã nguồn trước khi kiểm thử (phát hiện 6 điểm bất hợp lý), đến việc áp dụng thành thạo các kỹ thuật thiết kế test case (phân vùng tương đương, giá trị biên, bảng quyết định) và thực thi kiểm thử, quản lý lỗi một cách bài bản. Nhóm cũng rèn luyện được kỹ năng làm việc nhóm theo mô hình phân tầng và quy trình Peer Review trước khi merge code — một quy trình chuyên nghiệp thường thấy trong các dự án phần mềm thực tế.

## 5.3. Những hạn chế và hướng phát triển

Dù đã đạt được nhiều kết quả tích cực, nhóm cũng nhận thức rõ những hạn chế còn tồn tại và đề xuất các hướng phát triển cho tương lai.

Về hạn chế, hai lỗi Major (BUG-01 và BUG-02) vẫn chưa được khắc phục trong phạm vi thời gian của đồ án. Ngoài ra, các Unit Test hiện tại chỉ kiểm thử logic thuần túy (tách biệt khỏi cơ sở dữ liệu), chưa có các Integration Test thực sự kết nối với SQL Server để kiểm tra hành vi của Entity Framework Core như cascade delete hay transaction. Việc kiểm thử thủ công trên giao diện chưa được tự động hóa, khiến cho việc chạy lại toàn bộ test case mỗi khi có thay đổi trở nên tốn thời gian và dễ bỏ sót lỗi hồi quy. Cuối cùng, các kiểm thử bảo mật (như SQL Injection, XSS) và hiệu năng (tải cao) chưa được thực hiện, như đã nêu trong phạm vi Out-of-scope.

| **Mã** | **Hạn chế** | **Mức độ** | **Hướng phát triển** |
| --- | --- | --- | --- |
| HC-01 | 2 lỗi Major (BUG-01, BUG-02) chưa khắc phục | Major | Ưu tiên cao nhất: fix lỗi, kiểm thử hồi quy |
| HC-02 | Chưa có Integration Test với DB thực | Trung bình | Dùng WebApplicationFactory + SQLite In-Memory |
| HC-03 | Chưa tự động hóa kiểm thử giao diện | Trung bình | Playwright/Selenium cho luồng quan trọng |
| HC-04 | Chưa kiểm thử bảo mật & hiệu năng | Trung bình | OWASP ZAP (bảo mật), k6/JMeter (hiệu năng) |
| HC-05 | Quy trình Review chưa phát hiện sớm lỗi Major | Minor | Checklist chi tiết hơn, tập trung ánh xạ dữ liệu |

*Bảng 5.2 – Tóm tắt hạn chế và hướng phát triển*

Về hướng phát triển, nhóm đề xuất bổ sung Integration Test sử dụng WebApplicationFacory kết hợp với SQLite In-Memory để kiểm tra tầng Infrastructure và hành vi của EF Core một cách thực tế. Triển khai kiểm thử tự động hóa giao diện bằng Playwright hoặc Selenium cho các luồng quan trọng như Đăng nhập, Đặt hàng, và Admin CRUD. Tích hợp CI/CD (GitHub Actions) để tự động chạy bộ Unit Test mỗi khi có Pull Request, ngăn lỗi hồi quy ngay từ sớm. Bổ sung kiểm thử bảo mật cơ bản bằng OWASP ZAP và kiểm thử hiệu năng bằng k6 hoặc JMeter cho bản phát hành chính thức. Cuối cùng, chuẩn hóa lại quy trình Review với checklist chi tiết hơn, tập trung vào các lỗi dạng thiếu ánh xạ dữ liệu (như BUG-01) và sai thứ tự thao tác (như BUG-02), để phát hiện sớm những vấn đề này ngay từ giai đoạn tĩnh.

# PHỤ LỤC – BẢNG CHÚ THÍCH THUẬT NGỮ TIẾNG ANH

| **Thuật ngữ tiếng Anh** | **Giải thích / Dịch nghĩa tiếng Việt** |
| --- | --- |
| **Admin** | Quản trị viên: người có quyền cao nhất trong hệ thống, xuất hiện xuyên suốt trong các luồng quản trị và phân quyền. |
| **Api** | Tầng cung cấp các điểm cuối cho hệ thống, phục vụ tích hợp với ứng dụng khác. |
| **Application** | Tầng ứng dụng: nơi chứa các dịch vụ và logic nghiệp vụ. |
| **ASP.NET Core MVC** | Khung ứng dụng web mã nguồn mở, đa nền tảng của Microsoft, dùng để xây dựng ứng dụng web theo mô hình MVC. |
| **BCrypt** | Thuật toán băm mật khẩu có chèn muối (salt), được dùng để mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu. |
| **Bug** | Lỗi – sự sai lệch giữa hành vi thực tế và hành vi mong đợi của phần mềm, xuất hiện trong tên lỗi (BUG-01...). |
| **Bug Log** | Nhật ký lỗi: danh sách ghi nhận tất cả các lỗi phát hiện, được trình bày ở Chương 4.2. |
| **cancelled** | Trạng thái đơn hàng đã hủy. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **CI/CD (Continuous Integration / Continuous Deployment)** | Tích hợp liên tục / Triển khai liên tục xuất hiện trong hướng phát triển (HC-03). |
| **Clean Architecture** | Kiến trúc phần mềm ưu tiên tầng miền và nghiệp vụ, các tầng ngoài phụ thuộc vào tầng trong. |
| **confirmed** | Trạng thái đơn hàng đã xác nhận. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Console.WriteLine** | Lệnh in ra cửa sổ console, thường dùng để debug; xuất hiện trong R3 (còn sót trong code production). |
| **Cookie Authentication** | Cơ chế xác thực dựa trên cookie, được sử dụng để duy trì phiên đăng nhập. |
| **CSRF (Cross-Site Request Forgery)** | Tấn công giả mạo yêu cầu, xuất hiện trong TC\_F16\_03 kiểm tra lỗ hổng CSRF. |
| **Customer** | Khách hàng: người dùng đã đăng nhập, có quyền mua hàng và quản lý đơn hàng của mình. |
| **Debug** | Gỡ lỗi: xuất hiện trong R3 (còn sót lệnh debug) và BUG-04. |
| **Domain** | Tầng miền: chứa các thực thể nghiệp vụ cốt lõi và giao diện kho lưu trữ. |
| **done** | Trạng thái đơn hàng hoàn thành. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Entity Framework Core** | Công cụ ánh xạ đối tượng, quan hệ của Microsoft, dùng để thao tác cơ sở dữ liệu. |
| **Fail** | Thất bại: ca kiểm thử không thành công, xuất hiện trong các bảng kết quả kiểm thử. |
| **GitHub Actions** | Nền tảng CI/CD tích hợp trong GitHub, xuất hiện trong hướng phát triển (HC-03). |
| **IDOR (Insecure Direct Object Reference)** | Lỗ hổng tham chiếu đối tượng trực tiếp, xuất hiện trong các test case F08, F10, F11, F12. |
| **Infrastructure** | Tầng hạ tầng: triển khai cụ thể các kho lưu trữ và kết nối cơ sở dữ liệu. |
| **JMeter** | Công cụ kiểm thử tải nguồn mở, xuất hiện trong hướng phát triển (HC-04). |
| **k6** | Công cụ kiểm thử tải và hiệu năng mã nguồn mở, xuất hiện trong hướng phát triển (HC-04). |
| **Moq** | Thư viện tạo đối tượng giả trong kiểm thử, thay thế các phụ thuộc thật. |
| **NULL** | Rỗng: giá trị không trỏ đến đối tượng nào, xuất hiện trong R6 (lỗi do không kiểm tra null). |
| **NUnit** | Khung kiểm thử đơn vị cho C# và .NET, dùng để viết và chạy các Unit Test. |
| **NUnit3TestAdapter** | Bộ điều hợp để chạy NUnit test trong Visual Studio. |
| **Out-of-scope** | Ngoài phạm vi: xuất hiện trong mục 1.3.3 và hướng phát triển (HC-04). |
| **OWASP ZAP** | Công cụ kiểm thử bảo mật ứng dụng web, xuất hiện trong hướng phát triển (HC-04). |
| **Pass** | Đạt: ca kiểm thử thành công, xuất hiện trong các bảng kết quả kiểm thử. |
| **Peer Review** | Đánh giá đồng nghiệp, xuất hiện trong mục 5.2 (quy trình làm việc nhóm). |
| **pending** | Trạng thái đơn hàng chờ xác nhận. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Playwright** | Công cụ tự động hóa kiểm thử web hiện đại, xuất hiện trong mục 1.3.3 và hướng phát triển. |
| **Production Code** | Mã nguồn sản xuất, xuất hiện trong R3 (còn sót debug trong code production). |
| **Selenium** | Công cụ tự động hóa kiểm thử giao diện web, xuất hiện trong mục 1.3.3. |
| **shipping** | Trạng thái đơn hàng đang vận chuyển. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Sold** | Số lượng đã bán, trường dữ liệu của sản phẩm, xuất hiện trong các test case và bảng dữ liệu. |
| **SQL Injection** | Tấn công SQL, xuất hiện trong TC\_F01\_10 và TC\_F02\_08 (kiểm tra bảo mật). |
| **SQL Server** | Hệ quản trị cơ sở dữ liệu quan hệ do Microsoft phát triển, được sử dụng trong dự án. |
| **SRS (Software Requirements Specification)** | Đặc tả yêu cầu phần mềm, xuất hiện trong R5 (thiếu tài liệu SRS). |
| **Stock** | Số lượng tồn kho: trường dữ liệu của sản phẩm, xuất hiện trong các test case và bảng dữ liệu. |
| **Test Case (TC)** | Ca kiểm thử: bộ các bước thực hiện, dữ liệu đầu vào và kết quả mong đợi để kiểm tra một chức năng. |
| **Tests** | Tầng kiểm thử: dự án chứa các Unit Test và Integration Test. |
| **Total** | Tổng tiền: trường dữ liệu của đơn hàng, xuất hiện trong các test case và bảng dữ liệu. |
| **Unit Test** | Kiểm thử đơn vị: kiểm tra từng phần nhỏ nhất của mã nguồn một cách độc lập. |
| **usecase** | Ca sử dụng, xuất hiện trong sơ đồ usecase (Sơ đồ 1.2). |
| **Web** | Tầng giao diện: chứa Controller, View và tài nguyên tĩnh. |
| **XSS (Cross-Site Scripting)** | Tấn công chèn script: xuất hiện trong TC\_F01\_10 (kiểm tra bảo mật form đăng ký). |
| **Admin** | Quản trị viên: người có quyền cao nhất trong hệ thống, xuất hiện xuyên suốt trong các luồng quản trị và phân quyền. |
| **Api** | Tầng cung cấp các điểm cuối cho hệ thống, phục vụ tích hợp với ứng dụng khác. |
| **Application** | Tầng ứng dụng: nơi chứa các dịch vụ và logic nghiệp vụ. |
| **ASP.NET Core MVC** | Khung ứng dụng web mã nguồn mở, đa nền tảng của Microsoft, dùng để xây dựng ứng dụng web theo mô hình MVC. |
| **BCrypt** | Thuật toán băm mật khẩu có chèn muối, được dùng để mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu. |
| **Bug** | Lỗi: sự sai lệch giữa hành vi thực tế và hành vi mong đợi của phần mềm, xuất hiện trong tên lỗi (BUG-01...). |
| **Bug Log** | Nhật ký lỗi: danh sách ghi nhận tất cả các lỗi phát hiện, được trình bày ở Chương 4.2. |
| **cancelled** | Trạng thái đơn hàng đã hủy. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **CI/CD (Continuous Integration / Continuous Deployment)** | Tích hợp liên tục / Triển khai liên tục: xuất hiện trong hướng phát triển (HC-03). |
| **Clean Architecture** | Kiến trúc phần mềm ưu tiên tầng miền và nghiệp vụ, các tầng ngoài phụ thuộc vào tầng trong. |
| **confirmed** | Trạng thái đơn hàng đã xác nhận. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Console.WriteLine** | Lệnh in ra cửa sổ console, thường dùng để debug; xuất hiện trong R3 (còn sót trong code production). |
| **Cookie Authentication** | Cơ chế xác thực dựa trên cookie, được sử dụng để duy trì phiên đăng nhập. |
| **CSRF (Cross-Site Request Forgery)** | Tấn công giả mạo yêu cầu: xuất hiện trong TC\_F16\_03 kiểm tra lỗ hổng CSRF. |
| **Customer** | Khách hàng: người dùng đã đăng nhập, có quyền mua hàng và quản lý đơn hàng của mình. |
| **Debug** | Gỡ lỗi: xuất hiện trong R3 (còn sót lệnh debug) và BUG-04. |
| **Domain** | Tầng miền: chứa các thực thể nghiệp vụ cốt lõi và giao diện kho lưu trữ. |
| **done** | Trạng thái đơn hàng hoàn thành. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Entity Framework Core** | Công cụ ánh xạ đối tượng: quan hệ của Microsoft, dùng để thao tác cơ sở dữ liệu. |
| **Fail** | Thất bại: ca kiểm thử không thành công, xuất hiện trong các bảng kết quả kiểm thử. |
| **GitHub Actions** | Nền tảng CI/CD tích hợp trong GitHub, xuất hiện trong hướng phát triển (HC-03). |
| **IDOR (Insecure Direct Object Reference)** | Lỗ hổng tham chiếu đối tượng trực tiếp: xuất hiện trong các test case F08, F10, F11, F12. |
| **Infrastructure** | Tầng hạ tầng: triển khai cụ thể các kho lưu trữ và kết nối cơ sở dữ liệu. |
| **JMeter** | Công cụ kiểm thử tải nguồn mở, xuất hiện trong hướng phát triển (HC-04). |
| **k6** | Công cụ kiểm thử tải và hiệu năng mã nguồn mở, xuất hiện trong hướng phát triển (HC-04). |
| **Moq** | Thư viện tạo đối tượng giả trong kiểm thử, thay thế các phụ thuộc thật. |
| **NULL** | Rỗng – giá trị không trỏ đến đối tượng nào, xuất hiện trong R6 (lỗi do không kiểm tra null). |
| **NUnit** | Khung kiểm thử đơn vị cho C# và .NET, dùng để viết và chạy các Unit Test. |
| **NUnit3TestAdapter** | Bộ điều hợp để chạy NUnit test trong Visual Studio. |
| **Out-of-scope** | Ngoài phạm vi: xuất hiện trong mục 1.3.3 và hướng phát triển (HC-04). |
| **OWASP ZAP** | Công cụ kiểm thử bảo mật ứng dụng web, xuất hiện trong hướng phát triển (HC-04). |
| **Pass** | Đạt: ca kiểm thử thành công, xuất hiện trong các bảng kết quả kiểm thử. |
| **Peer Review** | Đánh giá đồng nghiệp: xuất hiện trong mục 5.2 (quy trình làm việc nhóm). |
| **pending** | Trạng thái đơn hàng chờ xác nhận. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Playwright** | Công cụ tự động hóa kiểm thử web hiện đại, xuất hiện trong mục 1.3.3 và hướng phát triển. |
| **Production Code** | Mã nguồn sản xuất: xuất hiện trong R3 (còn sót debug trong code production). |
| **Selenium** | Công cụ tự động hóa kiểm thử giao diện web, xuất hiện trong mục 1.3.3. |
| **shipping** | Trạng thái đơn hàng đang vận chuyển. Xuất hiện trong vòng đời đơn hàng và các test case. |
| **Sold** | Số lượng đã bán: trường dữ liệu của sản phẩm, xuất hiện trong các test case và bảng dữ liệu. |
| **SQL Injection** | Tấn công SQL: xuất hiện trong TC\_F01\_10 và TC\_F02\_08 (kiểm tra bảo mật). |