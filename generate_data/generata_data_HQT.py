import random
from faker import Faker
import csv

fake = Faker('en_US')  # Sử dụng Faker để tạo dữ liệu giả mạo
# Hàm tạo dữ liệu cho một bệnh nhân
previous_code = 0
previous_code_v2 = 0
previous_code_v3 = 0

def generate_incremental_code():
    global previous_code
    previous_code += 1
    return f"{previous_code:02d}"
def generate_incremental_code_v2():
    global previous_code_v2
    previous_code_v2 += 1
    return f"{previous_code_v2:02d}"
def generate_incremental_code_v3():
    global previous_code_v3
    previous_code_v3 += 1
    return f"{previous_code_v3:02d}"
def generate_fake_medicine_name():
    prefix = ['Aspirin', 'Tylenol', 'Ibuprofen', 'Advil', 'Aleve', 'Motrin']
    suffix = ['Tablet', 'Capsule', 'Injection', 'Syrup', 'Gel', 'Cream']
    medicine_name = f"{random.choice(prefix)} {fake.word()} {random.choice(suffix)}"
    return medicine_name  
#Khach Hang
def generate_KhachHang():
    index =  generate_incremental_code()
    MaBN = index
    HoTen = fake.name()
    NgaySinh = fake.date()
    DiaChi = f"{fake.building_number()}{fake.street_name()}"
    SoDienThoai = fake.random_number(digits = 10)
    MatKhau = index
    Ban = 0
    return MaBN, HoTen, NgaySinh, DiaChi, SoDienThoai, MatKhau, Ban
# Tạo danh sách 1000 bệnh nhân
def generate_data_KhachHang():
    KhachHang = [generate_KhachHang() for _ in range(100)]
    # Ghi dữ liệu ra file CSV
    with open('data_KhachHang.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow(['MaBN', 'HoTen', 'NgaySinh', 'DiaChi', 'SoDienThoai', 'MaKhau', 'Ban' ])
        # Ghi dữ liệu
        writer.writerows(KhachHang)
    print("Dữ liệu đã được tạo và lưu vào file 'data_KhachHang.csv'")

# NhaSi

def generate_NhaSi():
    index = generate_incremental_code()
    MaNhaSi = index
    HoTen = fake.name()
    SoDienThoai = fake.random_number(digits = 10)
    MatKhau = index
    DayWeek = [1,2,3,4,5,6,7]
    Size = fake.random_int(1,7)
    LichLam_temp = random.sample(DayWeek,Size)
    LichLam = '-'.join(str(LichLam_temp[i]) for i in range(Size))
    Ban = 0
    return MaNhaSi, HoTen, SoDienThoai, MatKhau, LichLam, Ban
# Tạo danh sách 1000 bệnh nhân
def generate_data_nhasi():
    NhaSi = [generate_NhaSi() for _ in range(100)]
    # Ghi dữ liệu ra file CSV
    with open('data_NhaSi.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow(['MaNhaSi', 'HoTen', 'SoDienThoai', 'MatKhau', 'LichLam', 'Ban'])
        # Ghi dữ liệu
        writer.writerows(NhaSi)
    print("Dữ liệu đã được tạo và lưu vào file 'data_NhaSi.csv'")


#Thuoc
def generate_Thuoc():
    index = generate_incremental_code()
    MaThuoc = f"{"TH"}{index}"
    TenThuoc = generate_fake_medicine_name()
    DonViTinh = fake.random_int(5,50) * 100
    ChiDinh =f"Chỉ Định {index}"
    SoLuongTon = fake.random_int(30,1000)
    NgayHenHan = fake.date()
    return MaThuoc, TenThuoc, DonViTinh, ChiDinh, SoLuongTon, NgayHenHan

def generate_data_Thuoc():
    Thuoc = [generate_Thuoc() for _ in range(100)]
    # Ghi dữ liệu ra file CSV
    with open('data_Thuoc.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow(['MaThuoc', 'TenThuoc', 'DonViTinh', 'ChiDinh', 'SoLuongTon', 'NgayHenHan'])
        # Ghi dữ liệu
        writer.writerows(Thuoc)
    print("Dữ liệu đã được tạo và lưu vào file 'data_Thuoc.csv'")

# lịch hẹn 
def generate_lichHen():
    NgayGio = fake.date()
    MaBN = generate_incremental_code()
    MaNhaSi = fake.random_int(1,100)
    NhaSiDat = fake.random_int(0,1)
    return NgayGio, MaBN, MaNhaSi, NhaSiDat
def generate_data_LichHen():
    lich = [generate_lichHen() for _ in range(100)]
    # Ghi dữ liệu ra file CSV
    with open('data_LichHen.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow([ 'NgayGio', 'MaBN', 'MaNhaSi', 'NhaSiDat'])
        # Ghi dữ liệu
        writer.writerows(lich)
    print("Dữ liệu đã được tạo và lưu vào file 'data_LichHen.csv'")

def generate_HoSoBenhNhan(index):
    global previous_code, previous_code_v2, previous_code_v3
    if index % 2 == 0:
        MaBN =  generate_incremental_code()
        STTu = generate_incremental_code_v2()
    else:
        
        previous_code -= 1
        MaBN =  generate_incremental_code()
        STTu = generate_incremental_code_v2()
        previous_code_v2 = 0
    DonThuoc = generate_incremental_code_v3()
    NgayKham = fake.date()
    NhaSi = fake.random_int(1,100)
    PhiKham = fake.random_int(200,1000) * 1000

    DV_Table = ["chụp Xquang", "trám răng", "cạo vôi"]
    DichVu = fake.random.choice(DV_Table)
    return STTu,DonThuoc,MaBN,NgayKham,NhaSi,PhiKham,DichVu
def generate_data_HoSoBenhNhan():
    HSBNhan = [generate_HoSoBenhNhan(_) for _ in range(50)]
    # Ghi dữ liệu ra file CSV
    with open('data_HoSoBenhNhan.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow([ 'STT','DonThuoc','MaBN','NgayKham','NhaSi','PhiKham','DichVu'])
        # Ghi dữ liệu
        writer.writerows(HSBNhan)
    print("Dữ liệu đã được tạo và lưu vào file 'data_HoSoBenhNhan.csv'")
    
#DonThuoc
    
def generate_DonThuoc(index):
    global previous_code  # Add this line to indicate the use of the global variable
    global previous_code_v2  # Add this line to indicate the use of the global variable
    if index % 2 == 0:
        MaDH =  f"DT{generate_incremental_code()}"
    else:
        previous_code -= 1
        MaDH =  f"DT{generate_incremental_code()}"
    MaThuoc = f"TH{generate_incremental_code_v2()}"
    return MaDH, MaThuoc
def generate_data_DonThuoc():
    # Tạo danh sách 100000 tên thuốc
    DonThuoc = [generate_DonThuoc(_) for _ in range(100)]

    # Ghi dữ liệu ra file CSV
    with open('data_DonThuoc.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow(['DonThuoc', 'MaThuoc'])
        # Ghi dữ liệu
        writer.writerows(DonThuoc)

    print("Dữ liệu đã được tạo và lưu vào file 'data_DonTHuoc.csv'")

# Nhân Viên
    previous_code = 0
def generate_NhanVien():
   # Add this line to indicate the use of the global 
    index = generate_incremental_code()
    MaNV = index
    HoTen = fake.name()
    MatKhau = index
    return MaNV,HoTen,MatKhau
def generate_data_NhanVien():
    # Tạo danh sách 100000 tên thuốc
    DonThuoc = [generate_NhanVien() for _ in range(100)]

    # Ghi dữ liệu ra file CSV
    with open('data_NhanVien.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow(['MaNV','HoTen','MatKhau'])
        # Ghi dữ liệu
        writer.writerows(DonThuoc)

    print("Dữ liệu đã được tạo và lưu vào file 'data_NhanVien.csv'")


#Quan Tri Vien
previous_code = 0
def generate_QuanTriVien():
   # Add this line to indicate the use of the global 
    index = generate_incremental_code()
    MaNV = index
    HoTen = fake.name()
    MatKhau = index
    return MaNV,HoTen,MatKhau
def generate_data_QuanTriVien():
    # Tạo danh sách 100000 tên thuốc
    DonThuoc = [generate_QuanTriVien() for _ in range(100)]
    # Ghi dữ liệu ra file CSV
    with open('data_QuanTriVien.csv', 'w', newline='', encoding='utf-8') as file:
        writer = csv.writer(file)
        # Ghi header
        writer.writerow(['MaNV','HoTen','MatKhau'])
        # Ghi dữ liệu
        writer.writerows(DonThuoc)
    print("Dữ liệu đã được tạo và lưu vào file 'data_QuanTriVien.csv'")

#generate_data_KhachHang()
#generate_data_nhasi()
#generate_data_Thuoc()
#generate_data_LichHen()
#generate_data_DonThuoc()
#generate_data_HoSoBenhNhan()
#generate_data_QuanTriVien()
generate_data_NhanVien()