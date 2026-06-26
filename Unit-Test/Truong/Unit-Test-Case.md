# 📋 Tổng hợp Test Case – Unit Test Advance

## Question 1 – SolveEquation
| Test Case ID | Input (number1, number2) | Expected Result | Description                        |
|--------------|---------------------------|-----------------|------------------------------------|
| TC01         | (0, 0)                   | "Multi roots"   | Kiểm tra phương trình vô số nghiệm |
| TC02         | (0, 5)                   | "No root"       | Kiểm tra phương trình vô nghiệm    |
| TC03         | (3, 7)                   | "One root"      | Kiểm tra phương trình có một nghiệm |

---

## Question 2 – MaxNumber1
| Test Case ID | Input (n1, n2, n3) | Expected Result | Description                  |
|--------------|---------------------|-----------------|------------------------------|
| TC01         | (10, 5, 3)         | 10              | Số 1 lớn nhất                |
| TC02         | (5, 10, 3)         | 10              | Số 2 lớn nhất                |
| TC03         | (5, 3, 10)         | 10              | Số 3 lớn nhất                |
| TC04         | (10, 10, 5)        | 10              | Số 1 = Số 2 > Số 3           |
| TC05         | (5, 10, 10)        | 10              | Số 2 = Số 3 > Số 1           |
| TC06         | (10, 5, 10)        | 10              | Số 1 = Số 3 > Số 2           |
| TC07         | (7, 7, 7)          | 7               | Ba số bằng nhau              |

---

## Question 3 – MaxNumber2
| Test Case ID | Input (n1, n2) | Expected Result | Description       |
|--------------|----------------|-----------------|-------------------|
| TC01         | (10, 5)        | 10              | Số 1 lớn hơn      |
| TC02         | (5, 10)        | 10              | Số 2 lớn hơn      |
| TC03         | (7, 7)         | 7               | Hai số bằng nhau  |

---

## Question 4 – Sort1 (Tăng dần)
| Test Case ID | Input (n1, n2) | Expected Result | Description                 |
|--------------|----------------|-----------------|-----------------------------|
| TC01         | (10, 3)        | (3, 10)         | Đổi chỗ khi n1 > n2         |
| TC02         | (2, 5)         | (2, 5)          | Giữ nguyên khi n1 < n2      |

---

## Question 5 – Sort2 (Giảm dần)
| Test Case ID | Input (n1, n2) | Expected Result | Description                 |
|--------------|----------------|-----------------|-----------------------------|
| TC01         | (10, 3)        | (10, 3)         | Giữ nguyên khi n1 > n2      |
| TC02         | (3, 10)        | (10, 3)         | Đổi chỗ khi n1 < n2         |

---

## Question 6 – Triangle
| Test Case ID | Input (n1, n2, n3) | Expected Result | Description     |
|--------------|---------------------|-----------------|-----------------|
| TC01         | (9, 4, 1)          | 9               | Cạnh 1 lớn nhất |
| TC02         | (3, 9, 5)          | 9               | Cạnh 2 lớn nhất |
| TC03         | (2, 4, 8)          | 8               | Cạnh 3 lớn nhất |

---

## Question 7 – Advance1 (USCLN & BSCNN)
| Test Case ID | Input (a, b) | Expected Result | Description       |
|--------------|--------------|-----------------|-------------------|
| TC01         | (12, 8)      | 4               | USCLN cơ bản      |
| TC02         | (4, 6)       | 12              | BSCNN cơ bản      |
| TC03         | (0, 4)       | Exception       | a = 0 gây lỗi     |
| TC04         | (4, 0)       | Exception       | b = 0 gây lỗi     |
| TC05         | (-4, 8)      | Exception       | a âm gây lỗi      |

---

## Question 8 – Advance2 (Sum digits)
| Test Case ID | Input | Expected Result | Description         |
|--------------|-------|-----------------|---------------------|
| TC01         | 5765  | 23              | Tổng chữ số dương   |
| TC02         | -123  | -6              | Tổng chữ số âm      |
| TC03         | 0     | 0               | Trường hợp số 0     |

---

## Question 9 – Advance3 (Fibonacci)
| Test Case ID | Input (n) | Expected Result | Description          |
|--------------|-----------|-----------------|----------------------|
| TC01         | 5         | 5               | Fibonacci cơ bản     |
| TC02         | -3        | -1              | n âm trả về -1       |
| TC03         | 0         | 0               | F0 = 0               |

---

## Question 10 – Advance4 (Prime check)
| Test Case ID | Input (n) | Expected Result | Description             |
|--------------|-----------|-----------------|-------------------------|
| TC01         | 7         | true            | Số nguyên tố            |
| TC02         | 6         | false           | Không nguyên tố         |
| TC03         | -3        | false           | Số âm không nguyên tố   |

---

## Question 11 – Advance5 (Palindrome)
| Test Case ID | Input (n) | Expected Result | Description            |
|--------------|-----------|-----------------|------------------------|
| TC01         | 12121     | true            | Chuỗi đối xứng         |
| TC02         | 0         | true            | Số 0 đối xứng          |
| TC03         | -102      | false           | Không đối xứng         |
| TC04         | -101      | false           | Theo code hiện tại     |

---

## Question 12 – Advance6 (Age calculation)
| Test Case ID | Input (day, month, year) | Expected Result | Description       |
|--------------|---------------------------|-----------------|-------------------|
| TC01         | (12, 1, 1999)            | ~27             | Tuổi hợp lệ       |
| TC02         | (12, 1, 2030)            | Exception / -1  | Ngày tương lai    |
| TC03         | (-12, 1, 2000)           | Exception       | Ngày âm           |
| TC04         | (12, -1, 2000)           | Exception       | Tháng âm          |
| TC05         | (12, 1, -2030)           | Exception       | Năm âm            |

---

## Question 13 – Advance7 (Day of week)
| Test Case ID | Input (day, month, year) | Expected Result | Description             |
|--------------|---------------------------|-----------------|-------------------------|
| TC01         | (6, 4, 2020)             | 2 (Monday)      | Ngày hợp lệ             |
| TC02         | (35, 6, 2019)            | 1–7             | Calendar tự cuộn        |
| TC03         | (19, 35, 2020)           | Exception       | Tháng không hợp lệ      |
| TC04         | (-19, 9, 2020)           | 1–7             | Ngày âm                 |
| TC05         | (19, -9, 2020)           | Exception       | Tháng âm                |
| TC06         | (19, 9, -2020)           | 1–7             | Năm âm (BC)             |

---

## Question 14 – ArraySum
| Test Case ID | Input (arr)          | Expected Result | Description        |
|--------------|----------------------|-----------------|--------------------|
| TC01         | {1,2,3,4,5}          | 15              | Mảng số dương      |
| TC02         | {-1,0,1}             | 0               | Mảng có âm và 0    |
| TC03         | {10,20,30,40,50}     | 150             | Mảng số lớn        |

---

## Question 15 – StringReversal
| Test Case ID | Input (str)     | Expected Result | Description            |
|--------------|-----------------|-----------------|------------------------|
| TC01         | "hello"         | "olleh"         | Chuỗi thường           |
| TC02         | "world"         | "dlrow"         | Chuỗi khác             |
| TC03         | ""              | ""              | Chuỗi rỗng             |
| TC04         | "a"             | "a"             | Một ký tự              |
| TC05         | "hello world"   | "dlrow olleh"   | Chuỗi có khoảng trắng  |

---

## Question 16 – LoginService
| Test Case ID | Input (username, password) | Expected Result | Description        |
|--------------|-----------------------------|-----------------|--------------------|
| TC01         | ("user","password")         | true            | Đăng nhập đúng     |
| TC02         | ("invalidUser","password")  | false           | Sai username       |
| TC03         | ("user","wrongPassword")    | false           | Sai password       |
| TC04         | ("guest","123456")          | false           | Sai cả hai         |
| TC05         | ("","")                     | false           | Rỗng cả hai        |
| TC06         | ("","password")             | false           | Username rỗng      |
| TC07         | ("user","")                 | false           | Password rỗng      |
| TC08         | (" user "," password ")     | false           | Có khoảng trắng    |
