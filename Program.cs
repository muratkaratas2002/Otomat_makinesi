namespace Otomat_makinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {

          


                String[] Malzemeler = new String[10];
                int[] Malzeme_fiyatları = new int[10];
                int[] Malzeme_adetleri = new int[10];

               
                Malzemeler[0] = "kola";
                Malzemeler[1] = "fanta"; 
                Malzemeler[2] = "çikolata";

                Malzeme_fiyatları[0] = 40;
                Malzeme_fiyatları[1] = 40;
                Malzeme_fiyatları[2] = 30;

                Malzeme_adetleri[0] = 10;
                Malzeme_adetleri[1] = 10;
                Malzeme_adetleri[2] = 10;

               
                int ürün_çeşitleri = 3;
                int toplam_satış = 0;
                int bakiye = 100;

                

                Console.WriteLine("Hoşgeldiniz\n1-Müşteri girişi\n2-Admin panel");
                int giriş = Convert.ToInt32(Console.ReadLine());

                while (giriş == 1)
                {
                    Console.WriteLine("Lütfen istediginiz ürün için sayı giriniz (Çıkış için 0)");

                    
                    for (int i = 0; i < ürün_çeşitleri; i++)
                    {
                        Console.WriteLine((i + 1) + " - " + Malzemeler[i] + " fiyatı " + Malzeme_fiyatları[i] + " Tl ");
                    }

                    int seçim = Convert.ToInt32(Console.ReadLine());

                    // Admin paneline gizli geçiş
                    if (seçim == 1283)
                    {
                        Console.WriteLine("admin paneline hoşgeldiniz");
                        giriş = 2; // Ana döngüyü kırıp admin döngüsüne geç
                        break;
                    }

                    
                    if (seçim == 0)
                    {
                        Console.WriteLine("Çıkış yapılıyor...");
                        giriş = 0; // Ana döngüyü kırmak için
                        break;
                    }

                  
                    int seçim_index = seçim - 1;

                  
                    if (seçim_index >= 0 && seçim_index < ürün_çeşitleri)
                    {
                        if (bakiye >= Malzeme_fiyatları[seçim_index])
                        {
                            if (Malzeme_adetleri[seçim_index] > 0)
                            {
                                bakiye -= Malzeme_fiyatları[seçim_index];
                                Malzeme_adetleri[seçim_index]--;
                                Console.WriteLine("Afiyet olsun para üstü " + bakiye + " Tl");
                                toplam_satış++;
                            }
                            else
                            {
                                Console.WriteLine("Ürün stokta kalmamıştır.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("yetersiz bakiye");
                            Console.WriteLine("1-para ekle\n 2-çıkış yap");
                            int bakiye_seçim = Convert.ToInt32(Console.ReadLine());
                            if (bakiye_seçim == 1)
                            {
                                Console.WriteLine("eklenecek tutarı giriniz");
                                int tutar = Convert.ToInt32(Console.ReadLine());
                                bakiye += tutar;
                                Console.WriteLine("bakiyeniz : " + bakiye);
                            }
                            else
                            {
                                Console.WriteLine("Çıkış yapılıyor...");
                                giriş = 0; // Ana döngüyü kırmak için
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("hatalı işlem");
                    }
                }

                while (giriş == 2)
                {
                    Console.WriteLine("\n--- Admin Panel ---");
                    Console.WriteLine("*********************");
                    Console.WriteLine("1-Yeni ürün ekleme\n2-Ürün güncelle\n3-Ürün sil\n4-Ürün listele\n5-Toplam satış adeti\n6-Müşteri paneline dön");
                    int admin_seçim = Convert.ToInt32(Console.ReadLine());

                    if (admin_seçim == 1) // YENİ ÜRÜN EKLEME
                    {
                        
                        if (ürün_çeşitleri < Malzemeler.Length)
                        {
                            Console.WriteLine("eklemek istediginiz ürün isimi giriniz");
                            String yeni_ürün = Console.ReadLine();
                            Malzemeler[ürün_çeşitleri] = yeni_ürün;
                            Console.WriteLine(yeni_ürün + " listeye eklendi");

                            Console.WriteLine("eklemek istediginiz ürünün fiyatını giriniz");
                            int fiyat = Convert.ToInt32(Console.ReadLine());
                            Malzeme_fiyatları[ürün_çeşitleri] = fiyat;
                            Console.WriteLine(yeni_ürün + " birim fiyatı " + Malzeme_fiyatları[ürün_çeşitleri] + " olarak berillendi");

                            Console.WriteLine("eklemek istediginiz ürünün adetini giriniz");
                            int adet = Convert.ToInt32(Console.ReadLine());
                            Malzeme_adetleri[ürün_çeşitleri] = adet;
                            Console.WriteLine(yeni_ürün + " adet sayısı " + Malzeme_adetleri[ürün_çeşitleri] + " olarak berillendi");

                            // Ürün sayısını artır
                            ürün_çeşitleri++;
                        }
                        else
                        {
                            Console.WriteLine("Makine dolu, yeni ürün eklenemez.");
                        }
                    }
                    else if (admin_seçim == 2) // ÜRÜN GÜNCELLEME
                    {
                        Console.WriteLine("Güncellemek istediginiz ürünü seçin");
                        // Mevcut tüm ürünleri listele
                        for (int i = 0; i < ürün_çeşitleri; i++)
                        {
                            // 'silinenler' veya 'fiyat!=0' kontrolüne gerek yok
                            Console.WriteLine((i + 1) + " - " + Malzemeler[i]);
                        }

                        int güncelleme_seçim = Convert.ToInt32(Console.ReadLine());
                        int guncelleme_index = güncelleme_seçim - 1; // 0 tabanlı indekse çevir

                        if (guncelleme_index >= 0 && guncelleme_index < ürün_çeşitleri)
                        {
                            Console.WriteLine("yeni ürün adı");
                            String yeni_ad = Console.ReadLine();
                            String eski_ad = Malzemeler[guncelleme_index];
                            Malzemeler[guncelleme_index] = yeni_ad;
                            Console.WriteLine(eski_ad + " isimli ürününüz " + yeni_ad + " olarak günçellenmiştir");

                            Console.WriteLine(Malzemeler[guncelleme_index] + " birim fiyatını giriniz");
                            int yeni_fiyat = Convert.ToInt32(Console.ReadLine());
                            Malzeme_fiyatları[guncelleme_index] = yeni_fiyat;
                            Console.WriteLine(Malzemeler[guncelleme_index] + " fiyatı " + Malzeme_fiyatları[guncelleme_index] + " olarak berillendi");

                            Console.WriteLine("yeni ürünün adetini giriniz");
                            int adet = Convert.ToInt32(Console.ReadLine());
                            Malzeme_adetleri[guncelleme_index] = adet;
                            Console.WriteLine(Malzemeler[guncelleme_index] + " adet sayısı " + Malzeme_adetleri[guncelleme_index] + " olarak berillendi");
                        }
                        else
                        {
                            Console.WriteLine("hatalı işlem");
                        }
                    }
                    else if (admin_seçim == 3) // ÜRÜN SİLME
                    {
                        // Mevcut tüm ürünleri listele
                        for (int i = 0; i < ürün_çeşitleri; i++)
                        {
                            Console.WriteLine((i + 1) + "-" + Malzemeler[i]);
                        }

                        Console.WriteLine("silmek istediginiz ürünün numarasını giriniz");
                        int sil = Convert.ToInt32(Console.ReadLine());
                        int sil_index = sil - 1; // 0 tabanlı indekse çevir

                        // Geçerli bir index mi kontrol et
                        if (sil_index >= 0 && sil_index < ürün_çeşitleri)
                        {
                            
                            for (int i = sil_index; i < ürün_çeşitleri - 1; i++)
                            {
                                // Sonraki elemanı mevcut elemanın üzerine yaz
                                Malzemeler[i] = Malzemeler[i + 1];
                                Malzeme_fiyatları[i] = Malzeme_fiyatları[i + 1];
                                Malzeme_adetleri[i] = Malzeme_adetleri[i + 1];
                            }

                            
                            ürün_çeşitleri--;

                            
                            Malzemeler[ürün_çeşitleri] = null;
                            Malzeme_fiyatları[ürün_çeşitleri] = 0;
                            Malzeme_adetleri[ürün_çeşitleri] = 0;

                            Console.WriteLine("ürün silinmiştir");
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim.");
                        }
                    }
                    else if (admin_seçim == 4) // ÜRÜN LİSTELEME
                    {
                        Console.WriteLine("ürünleriniz");
                        // Hata düzeltildi: i <= ürün_çeşitleri yerine i < ürün_çeşitleri olmalı
                        // (çünkü 3 ürün varsa indexler 0, 1, 2'dir)
                        for (int i = 0; i < ürün_çeşitleri; i++)
                        {
                            // 'fiyat != 0' kontrolüne gerek kalmadı, çünkü silme işlemi kaydırma yapıyor
                            Console.WriteLine(Malzemeler[i] + " fiyatı " + Malzeme_fiyatları[i] + " Tl, mevcut stok " + Malzeme_adetleri[i]);
                        }
                    }
                    else if (admin_seçim == 5) // TOPLAM SATIŞ
                    {
                        Console.WriteLine("yapılan toplam satış adeti:" + toplam_satış);
                    }
                    else if (admin_seçim == 6) // ÇIKIŞ
                    {
                        Console.WriteLine("Müşteri paneline dönülüyor...");
                        giriş = 1; // Müşteri döngüsüne geri dön
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz admin seçimi.");
                    }
                }

                if (giriş != 1 && giriş != 2) // Eğer ilk başta geçersiz giriş yapıldıysa
                {
                    Console.WriteLine("hatalı işlem");
                }

                Console.WriteLine("Program sonlandı. Kapatmak için bir tuşa basın.");
                
            }
        }
    }
