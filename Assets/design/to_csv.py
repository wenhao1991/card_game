import openpyxl
import pandas as pd
import os
 
input_filename =  'D:\\workspace\\Unity_Project\\design\\data'
out_filename='D:\\workspace\\Unity_Project\\design\\csv\\'
out_filename_utf8='D:\\workspace\\Unity_Project\\poker\\Assets\\Assets\\Data\\'

def xlsx_to_csv_pd(infile, outfile, sheetname, outfile_utf8=''):
    print(33, out_filename_utf8)
    data_xls = pd.read_excel(infile, index_col=0, sheet_name = sheetname)
    data_xls.rename( columns=lambda x: '' if 'Unnamed' in str(x) else x, inplace=True )
    data_xls.to_csv(outfile, encoding='gbk')    # 导出可读版本
    outfile_utf8 and data_xls.to_csv(outfile_utf8, encoding='utf-8')   # 项目里直接写入utf-8版本

 
def walk(path, func):
    for name in os.listdir(path):
        fpath = os.path.join(path, name)
        if os.path.isdir(fpath):
            walk(fpath, func)
        elif os.path.isfile(fpath):
            func(fpath, name)


if __name__ == '__main__':

    def func(fpath, name):
        if name.endswith("xlsx"):
            print(name)
            wb = openpyxl.load_workbook(fpath)
            namelist = wb.sheetnames
            print(namelist)

            for onesheet in namelist:
                print(f"onesheet: {onesheet}")
                sheetdata = wb[onesheet]
                # if 'Sheet' not in onesheet and 'skip' in str(sheetdata['A2'].value).lower():
                if 'Sheet' not in onesheet:
                    print(11, out_filename + onesheet + '.csv')
                    xlsx_to_csv_pd(fpath, out_filename + onesheet + '.csv', onesheet, out_filename_utf8 + onesheet + '.csv')
                    print(22)

    walk(input_filename, func)