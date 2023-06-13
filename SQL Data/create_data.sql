use QLDLRapPhim
go

-- Insert for CumRap
insert into CumRap values ('ABT', N'CGV Aeon Bình Tân', N'Tầng 3, Trung tâm thương mại Aeon Mall Bình Tân, Số 1 đường số 17A, khu phố 11, phường Bình Trị Đông B, quận Bình Tân, TPHCM')
insert into CumRap values ('VCL81', N'CGV Vincom Center Landmark 81', N'Tầng B1 , TTTM Vincom Center Landmark 81, 772 Điện Biên Phủ, P.22, Q. Bình Thạnh, HCM')
insert into CumRap values ('HVT', N'CGV Hoàng Văn Thụ', N'Tầng 1 và 2, Gala Center, số 415, Hoàng Văn Thụ, Phường 2, Quận Tân Bình, TPHCM')
go

--Insert for Rap
insert into Rap values ('CBT5', 162, 'ABT')
insert into Rap values ('CBT6', 146, 'ABT')
insert into Rap values ('CBT7', 300, 'ABT')

insert into Rap values ('VCLM3', 102, 'VCL81')
insert into Rap values ('VCLM4', 176, 'VCL81')
insert into Rap values ('VCLM7', 131, 'VCL81')

insert into Rap values ('HVT6', 286, 'HVT')
insert into Rap values ('HVT3', 84, 'HVT')
go

-- Insert for TheLoai
insert into TheLoai values ('ACTIO', 'Hành động')
insert into TheLoai values ('CRIMI', 'Tội phạm')
insert into TheLoai values ('CARTO', 'Hoạt hình')
insert into TheLoai values ('ADVEN', 'Phiêu lưu')
insert into TheLoai values ('COMED', 'Hài')
insert into TheLoai values ('NERVO', 'Hồi hộp')
insert into TheLoai values ('MENTA', 'Tâm lý')
insert into TheLoai values ('ROMAN', 'Tình cảm')
insert into TheLoai values ('LEGEN', 'Thần thoại')
insert into TheLoai values ('MYSTE', 'Bí ẩn')
insert into TheLoai values ('HORRO', 'Kinh dị')
go

-- Insert for Phim
insert into Phim values ('FAFX', N'FAST AND FURIOUS X', 'ACTIO', 141)
insert into Phim values ('DM42NSU23', N'PHIM ĐIỆN ẢNH DORAEMON: NOBITA VÀ VÙNG ĐẤT LÝ TƯỞNG TRÊN BẦU TRỜI', 'CARTO', 108)
insert into Phim values ('NTCMERMAID', N'NÀNG TIÊN CÁ', 'ADVEN', 135)
insert into Phim values ('LM6TVDM', N'LẬT MẶT 6: TẤM VÉ ĐỊNH MỆNH', 'COMED', 132)
insert into Phim values ('GOTGALAXY3', N'VỆ BINH DẢI NGÂN HÀ 3', 'ACTIO', 149)
insert into Phim values ('MBMETERNAL', N'CHÀNG TRAI XINH ĐẸP CỦA TÔI: ĐỜI ĐỜI KIẾP KIẾP', 'ROMAN', 103)
insert into Phim values ('TGAB2023', N'TIẾNG GỌI ÂM BINH', 'HORRO', 87)
insert into Phim values ('NKTTBENAFF', N'NHỮNG KẺ THAO TÚNG', 'MYSTE', 93)
insert into Phim values ('TSLOPETS', N'MÈO SIÊU QUẬY Ở VIỆN BẢO TÀNG', 'COMED', 80)
insert into Phim values ('DUNE2', N'DUNE: HÀNH TINH CÁT - PHẦN HAI', 'ACTIO', 0)
go

-- Insert for PhimTheLoaiPhu
insert into PhimTheLoaiPhu values ('FAFX', 'CRIMI')
insert into PhimTheLoaiPhu values ('LM6TVDM', 'ACTIO')
insert into PhimTheLoaiPhu values ('LM6TVDM', 'NERVO')
insert into PhimTheLoaiPhu values ('LM6TVDM', 'MENTA')
insert into PhimTheLoaiPhu values ('GOTGALAXY3', 'ADVEN')
insert into PhimTheLoaiPhu values ('GOTGALAXY3', 'LEGEN')
insert into PhimTheLoaiPhu values ('NKTTBENAFF', 'ACTIO')
insert into PhimTheLoaiPhu values ('NKTTBENAFF', 'NERVO')
insert into PhimTheLoaiPhu values ('TSLOPETS', 'CARTO')
insert into PhimTheLoaiPhu values ('TSLOPETS', 'ADVEN')
insert into PhimTheLoaiPhu values ('DUNE2', 'ADVEN')
insert into PhimTheLoaiPhu values ('DUNE2', 'MENTA')
go

-- Insert for KeHoach
insert into KeHoach values ('FAFX', 'ABT', '2023-05-19', '2023-06-01', '')
insert into KeHoach values ('FAFX', 'VCL81', '2023-05-19', '2023-06-01', '')
insert into KeHoach values ('FAFX', 'HVT', '2023-05-19', '2023-06-01', '')

insert into KeHoach values ('DM42NSU23', 'ABT', '2023-05-26', '2023-06-01', '')
insert into KeHoach values ('DM42NSU23', 'VCL81', '2023-05-26', '2023-06-01', '')
insert into KeHoach values ('DM42NSU23', 'HVT', '2023-05-26', '2023-06-01', '')

insert into KeHoach values ('NTCMERMAID', 'ABT', '2023-05-26', '2023-06-01', '')
insert into KeHoach values ('NTCMERMAID', 'VCL81', '2023-05-26', '2023-06-01', '')
insert into KeHoach values ('NTCMERMAID', 'HVT', '2023-05-26', '2023-06-01', '')

insert into KeHoach values ('LM6TVDM', 'ABT', '2023-04-28', '2023-05-31', '')
insert into KeHoach values ('LM6TVDM', 'VCL81', '2023-04-28', '2023-05-31', '')
insert into KeHoach values ('LM6TVDM', 'HVT', '2023-04-28', '2023-05-31', '')

insert into KeHoach values ('GOTGALAXY3', 'ABT', '2023-05-03', '2023-06-01', '')
insert into KeHoach values ('GOTGALAXY3', 'VCL81', '2023-05-03', '2023-05-31', '')
insert into KeHoach values ('GOTGALAXY3', 'HVT', '2023-05-03', '2023-06-01', '')

insert into KeHoach values ('MBMETERNAL', 'ABT', '2023-05-26', '2023-06-01', '')
insert into KeHoach values ('MBMETERNAL', 'VCL81', '2023-05-26', '2023-05-28', '')
insert into KeHoach values ('MBMETERNAL', 'HVT', '2023-05-26', '2023-06-01', '')

insert into KeHoach values ('TGAB2023', 'ABT', '2023-05-26', '2023-06-01', '')
insert into KeHoach values ('TGAB2023', 'VCL81', '2023-05-26', '2023-05-28', '')
insert into KeHoach values ('TGAB2023', 'HVT', '2023-05-26', '2023-06-01', '')

insert into KeHoach values ('NKTTBENAFF', 'ABT', '2023-05-12', '2023-05-20', '')
insert into KeHoach values ('NKTTBENAFF', 'VCL81', '2023-05-12', '2023-05-20', '')
insert into KeHoach values ('NKTTBENAFF', 'HVT', '2023-05-12', '2023-05-20', '')

insert into KeHoach values ('TSLOPETS', 'ABT', '2023-04-28', '2023-05-12', '')
insert into KeHoach values ('TSLOPETS', 'VCL81', '2023-04-28', '2023-05-12', '')
insert into KeHoach values ('TSLOPETS', 'HVT', '2023-04-28', '2023-05-12', '')

insert into KeHoach values ('DUNE2', 'ABT', '2023-11-03', '2023-11-30', '')
insert into KeHoach values ('DUNE2', 'VCL81', '2023-11-03', '2023-11-30', '')
insert into KeHoach values ('DUNE2', 'HVT', '2023-11-03', '2024-05-11', '')
go

-- Insert for SuatChieu
insert into SuatChieu values ('s1', 8, 0)
insert into SuatChieu values ('s2', 8, 30)
insert into SuatChieu values ('s3', 9, 0)
insert into SuatChieu values ('s4', 9, 30)
insert into SuatChieu values ('s5', 10, 0)
insert into SuatChieu values ('s6', 10, 30)
insert into SuatChieu values ('s7', 11, 0)
insert into SuatChieu values ('s8', 11, 30)
insert into SuatChieu values ('c1', 12, 0)
insert into SuatChieu values ('c2', 12, 30)
insert into SuatChieu values ('c3', 13, 0)
insert into SuatChieu values ('c4', 13, 30)
insert into SuatChieu values ('c5', 14, 0)
insert into SuatChieu values ('c6', 14, 30)
insert into SuatChieu values ('c7', 15, 0)
insert into SuatChieu values ('c8', 15, 30)
insert into SuatChieu values ('c9', 16, 0)
insert into SuatChieu values ('c10', 16, 30)
insert into SuatChieu values ('c11', 17, 0)
insert into SuatChieu values ('c12', 17, 30)
insert into SuatChieu values ('t1', 18, 0)
insert into SuatChieu values ('t2', 18, 30)
insert into SuatChieu values ('t3', 19, 0)
insert into SuatChieu values ('t4', 19, 30)
insert into SuatChieu values ('t5', 20, 0)
insert into SuatChieu values ('t6', 20, 30)
insert into SuatChieu values ('t7', 21, 0)
insert into SuatChieu values ('t8', 21, 30)
insert into SuatChieu values ('t9', 22, 0)
insert into SuatChieu values ('t10', 22, 30)
insert into SuatChieu values ('t11', 23, 0)
insert into SuatChieu values ('t12', 23, 30)
go

-- Insert for LichChieu
insert into LichChieu values ('FAFX', 'CBT7', '2023-05-26', 's1 s7 c5 c11 t5 t11')
insert into LichChieu values ('FAFX', 'CBT6', '2023-05-26', 's3 c1 c7 t1 t7')
insert into LichChieu values ('FAFX', 'CBT5', '2023-05-26', 's5 c3 c9 t3 t9')
insert into LichChieu values ('FAFX', 'CBT7', '2023-05-27', 's1 s7 c5 c11 t5 t11')

insert into LichChieu values ('FAFX', 'VCLM3', '2023-05-26', 'c8 t2 t8')
insert into LichChieu values ('FAFX', 'VCLM4', '2023-05-26', 'c12 t6')

insert into LichChieu values ('FAFX', 'HVT6', '2023-05-26', 'c2 c8 t2 t8')


insert into LichChieu values ('DM42NSU23', 'HVT3', '2023-05-26', 'c7 c12 t5 t10')