using System;
public class PhanSo
{
    private int _tuSo = 0, _mauSo = 1; // Đây là dữ liệu riêng (private), không cho phép truy xuất từ bên ngoài lớp

    public int TuSo
    {        // Thuộc tính (property)
        get { return _tuSo; }  // Đọc giá trị của trường _tuSo từ ngoài lớp
        // get => _tuSo;
        set { _tuSo = value; } // Thay đổi giá trị của trường _tuSo từ ngoài lớp
        // set => _tuSo = value;
    }

    public int MauSo
    {
        get => _mauSo; // Đọc giá trị của trường _mauSo
                       // Không có phương thức set -> không thay đổi được từ bên ngoài lớp
    }

    // Hàm thiết lập (constructor)
    public PhanSo(int tuSo = 0, int mauSo = 1)
    {
        // Mẫu số phải khác 0
        if (mauSo == 0)
            throw new ArgumentException("Mau so phai khac 0.", nameof(mauSo));
        this._tuSo = tuSo;
        this._mauSo = mauSo;
    }

    // Hàm thiết lập sao chép
    public PhanSo(PhanSo p)
    {
        _tuSo = p._tuSo;
        _mauSo = p._mauSo;
    }
    public void Nhap()
    {
        Console.Write("Tu so = ");
        _tuSo = Convert.ToInt32(Console.ReadLine());
        do
        {
            Console.Write("Mau so = ");
            _mauSo = Convert.ToInt32(Console.ReadLine());
            if (_mauSo == 0) Console.WriteLine("Mau so phai != 0");
        } while (_mauSo == 0);
    }
    public double GiaTri()
    {
        return Convert.ToDouble(_tuSo) / _mauSo;
    }

    public void Xuat()
    {
        Console.WriteLine("{0}/{1}", _tuSo, _mauSo);
    }

    static void Main(string[] args)
    {

        PhanSo p1 = new PhanSo(); // Tạo đối tượng phân số
        p1.Nhap();   // Gọi phương thức Nhap()
        p1.Xuat();   // Gọi phương thức Xuat()
        Console.WriteLine("Tu so = {0}", p1.TuSo);   // Thực hiện được vì thuộc tính TuSo cho phép đọc {get;} giá trị _tuSo
        Console.WriteLine("Mau so = {0}", p1.MauSo); // Thực hiện được vì thuộc tính MauSo cho phép đọc {get;} giá trị _mauSo       
        //p1.TuSo = 10;                              // Thực hiện được vì thuộc tính TuSo cho phép thay đổi {set;} giá trị _tuSo
        Console.WriteLine("Tu so = {0}", p1.TuSo);
        // p.MauSo = 10;                             // Không thực hiện được vì thuộc tính MauSo không cho thay đổi {set;} giá trị _mauSo
        // Tạo một mảng phân số
        Console.Write("Nhap so luong phan so: ");
        int numberOfElements = int.Parse(Console.ReadLine());
        PhanSo[] psList = new PhanSo[numberOfElements];

        // Nhập mảng phân số từ bàn phím
        for (int i = 0; i < numberOfElements; i++)
        {
            psList[i] = new PhanSo();
            psList[i].Nhap();
        }

        // In ra mảng phân số
        Console.WriteLine("Cac phan so vua nhap: ");
        for (int i = 0; i < numberOfElements; i++)
            psList[i].Xuat();

        // Tìm phân số lớn nhất
        PhanSo psMax = new PhanSo(psList[0]); // psMax = psList[0]  (gọi hàm thiết lập sao chép)
        for (int i = 1; i < numberOfElements; i++)
            if (psMax.GiaTri() < psList[i].GiaTri()) psMax = psList[i];
        Console.WriteLine("Phan so lon nhat la: ");
        psMax.Xuat();

        // Sắp xếp danh sách phân số tăng dần
        for (int i = 0; i < numberOfElements - 1; i++)
            for (int j = i + 1; j < numberOfElements; j++)
                if (psList[i].GiaTri() > psList[j].GiaTri())
                {
                    PhanSo tmp = new PhanSo(psList[i]);
                    psList[i] = psList[j];
                    psList[j] = tmp;
                }

        // In ra mảng phân số đã sắp xếp
        Console.WriteLine("Cac phan so theo thu tu tang dan: ");
        for (int i = 0; i < numberOfElements; i++)
            psList[i].Xuat();
    }
}