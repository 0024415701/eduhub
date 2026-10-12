
using System;
using System.Collections.Generic;
using System.Linq;
using EduHub.Domain;

// ==================================================
// NHIEM VU 4 - CONSOLE APP DEMO
// ==================================================

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("========================================");
Console.WriteLine("       EDHUB - QUAN LY CLB & SU KIEN");
Console.WriteLine("========================================");

// BUOC 1: Tao cau lac bo
Console.WriteLine("\n===== BUOC 1: TAO CAU LAC BO =====");

Club club = Club.Create(
    "Tech Club",
    "Cau lac bo cong nghe va lap trinh");

Console.WriteLine($"Ten CLB: {club.Name}");
Console.WriteLine($"Mo ta: {club.Description}");
Console.WriteLine($"Ma CLB: {club.Id}");

// BUOC 2: Them 3 thanh vien
Console.WriteLine("\n===== BUOC 2: THEM THANH VIEN =====");

Member member1 = Member.Create(
    "Nguyen Van An",
    "an@example.com",
    "SV001",
    DateTime.Now);

Member member2 = Member.Create(
    "Tran Thi Binh",
    "binh@example.com",
    "SV002",
    DateTime.Now);

Member member3 = Member.Create(
    "Le Van Cuong",
    "cuong@example.com",
    "SV003",
    DateTime.Now);

club.AddMember(member1);
club.AddMember(member2);
club.AddMember(member3);

foreach (Member member in club.Members)
{
    Console.WriteLine($"- {member.Name} | MSSV: {member.StudentCode}");
}

Console.WriteLine($"Tong so thanh vien: {club.MemberCount()}");

// BUOC 3: Tao su kien
Console.WriteLine("\n===== BUOC 3: TAO SU KIEN =====");

EduHub.Domain.Event workshop = EduHub.Domain.Event.Create(
    club.Id,
    "Workshop AI",
    DateTime.Now.AddDays(7),
    50,
    false);

Console.WriteLine($"Ten su kien: {workshop.Title}");
Console.WriteLine($"Ngay to chuc: {workshop.Date:dd/MM/yyyy HH:mm}");
Console.WriteLine($"Suc chua: {workshop.Capacity}");
Console.WriteLine($"Hinh thuc: {(workshop.IsOnline ? "Truc tuyen" : "Truc tiep")}");

// BUOC 4: Dang ky va xac nhan
Console.WriteLine("\n===== BUOC 4: DANG KY SU KIEN =====");

List<Registration> registrations = new List<Registration>();

if (workshop.HasCapacity(registrations.Count))
{
    Registration registration1 =
        Registration.Create(member1.Id, workshop.Id);

    registrations.Add(registration1);

    Console.WriteLine($"Thanh vien {member1.Name} dang ky.");
    Console.WriteLine($"Trang thai ban dau: {registration1.Status}");

    registration1.Confirm();

    Console.WriteLine($"Trang thai sau xac nhan: {registration1.Status}");
}

if (workshop.HasCapacity(registrations.Count))
{
    Registration registration2 =
        Registration.Create(member2.Id, workshop.Id);

    registrations.Add(registration2);

    Console.WriteLine($"\nThanh vien {member2.Name} dang ky.");
    Console.WriteLine($"Trang thai ban dau: {registration2.Status}");

    registration2.Confirm();

    Console.WriteLine($"Trang thai sau xac nhan: {registration2.Status}");
}

// BUOC 5: Diem danh mot thanh vien
Console.WriteLine("\n===== BUOC 5: DIEM DANH =====");

List<CheckIn> checkIns = new List<CheckIn>();

CheckIn checkIn = CheckIn.Create(
    registrations[0],
    CheckInMethod.QRCode);

checkIns.Add(checkIn);

Console.WriteLine($"Thanh vien: {member1.Name}");
Console.WriteLine($"Thong tin diem danh: {checkIn.Summary()}");

// BUOC 6: Bao cao tham du
Console.WriteLine("\n===== BUOC 6: BAO CAO THAM DU =====");

Console.WriteLine($"Su kien: {workshop.Title}");
Console.WriteLine($"So luong dang ky: {registrations.Count}");
Console.WriteLine($"So luong check-in: {checkIns.Count}");

Console.WriteLine("\nDanh sach thanh vien dang ky:");

foreach (Registration registration in registrations)
{
    Member? member = club.Members.FirstOrDefault(
        m => m.Id == registration.MemberId);

    if (member != null)
    {
        Console.WriteLine(
            $"- {member.Name} | Trang thai: {registration.Status}");
    }
}

Console.WriteLine("\nDanh sach diem danh:");

foreach (CheckIn item in checkIns)
{
    Member? member = club.Members.FirstOrDefault(
        m => registrations.Any(
            r => r.Id == item.RegistrationId
                 && r.MemberId == m.Id));

    if (member != null)
    {
        Console.WriteLine($"- {member.Name}");
        Console.WriteLine($"  {item.Summary()}");
    }
}

// BUOC 7: Thu nghiem luat nghiep vu
Console.WriteLine("\n===== BUOC 7: KIEM TRA NGOAI LE =====");

Registration cancelledRegistration =
    Registration.Create(member3.Id, workshop.Id);

cancelledRegistration.Cancel();

try
{
    cancelledRegistration.Confirm();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Da bat loi nghiep vu: {ex.Message}");
}

Console.WriteLine("\n========================================");
Console.WriteLine("       KET THUC CHUONG TRINH DEMO");
Console.WriteLine("========================================");

Console.WriteLine("\nNhan Enter de thoat...");
Console.ReadLine();
