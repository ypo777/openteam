# หาเพื่อนร่วมทีม Opendream 2022.01

[โอเพ่นดรีม][1] กำลังหา developer มาเป็นเพื่อนร่วมทีม โจทย์ทดสอบนี้หวังว่าจะทำให้เรารู้จักฝีมือกันมากขึ้น

# ลักษณะโจทย์

โจทย์จะมีทั้งหมด 3 ข้อ ดังนี้
## 01 - FizzBuzz

เขียนโปรแกรมที่รับ `input` เป็นชุดตัวเลข `1` ถึง `100` และแสดง `output` ตามเงื่อนไขดังนี้
- ถ้า `input` หารด้วย 3 ลงตัว แสดง `output` เป็น `Fizz`
- ถ้า `input` หารด้วย 5 ลงตัว แสดง `output` เป็น `Buzz`
- ถ้า `input` หารด้วย 3 และ 5 ลงตัว แสดง `output` เป็น `FizzBuzz`
- ถ้า `input` ไม่อยู่ในเงื่อนไขข้างต้น แสดง `output` เป็น `input`

## 02

เขียน function ให้เรียงลำดับคำตามพจนานุกรมไทย เช่น

### ตัวอย่างที่ 1

```
input = ["ไก่", "กา", "ขา", "แก", "แขวน", "เกีย"]
output = ["กา", "เกีย", "แก", "ไก่",  "ขา", "แขวน"]
```

### ตัวอย่างที่ 2

```
input = ["แอน", "นา", "ให้", "หา", "เอ"]
output = ["นา", "หา", "ให้",  "เอ", "แอน"]
```

## 03 - Front-end API Rendering

เขียน front-end ให้ดูแล้ว `สวยงาม` และไม่น่าเกลียดจนทนดูไม่ได้ โดยมีข้อกำหนดดังนี้
- Request `JSON` จากไฟล์ [posts.json][3] โดยเนื้อหาประกอบไปด้วย field ดังนี้
  - `userId`
  - `id`
  - `title`
  - `body`
  - `userAvatar`
- แสดงผลด้วย React หรือ Vue.js โดยมีข้อกำหนดเบื้องต้นดังนี้
  - แสดง pagination ของผลลัพธ์ทุกๆ 20 ผลลัพธ์
  - User สามารถเรียงลำดับผลลัพธ์ตาม `userId` หรือ `id` ได้ด้วยตัวเอง การเรียงลำดับให้ทำที่ client-side
  - แสดงผลแบบ responsive ได้
  - แสดง `userAvatar` เป็นวงกลมกิ๊บเก๋น่ารัก

## 04

เขียน function รับ `input` เป็น string และ return เป็นอีก string ที่นับจำนวนตัวอักษรใน `input` เป็น format input<sub>i</sub>`COUNT`<sub>i</sub>

```
Input: GOOGLE
Output: G2E2L1O2
```
```
Input: SCHOOL
Output: S1C1H1O2L1
```
Input: HELLOWORLD
Output: H1E1L3O2W1R1D1


# เงื่อนไขการทำโจทย์

ณ วันที่ 15 มิถุนายน 2564 เป็นต้นไป ผู้ทำโจทย์ สามารถเลือกทำโจทย์ด้วยภาษาโปรแกรมหรือเครื่องมือที่ตนเองถนัดได้ดังนี้

- โจทย์ที่ `01` และ `02` ใช้ภาษา `PHP` หรือ `Python`
- โจทย์ที่ `03` ใช้ `React` หรือ `Vue.js`

ผู้ทำโจทย์สามารถเลือกส่งโจทย์ได้ดังนี้
- โจทย์ที่ `01` และ `02`
- โจทย์ที่ `03`
- โจทย์ที่ `01`, `02` และ `03` - **ผู้เลือกทำเงื่อนไขนี้ จะได้รับการพิจารณาเป็นพิเศษ**
# วิธีส่งคำตอบ  

1. Fork repository นี้ไปยัง Github ของตัวเอง
2. สร้าง directory เป็น `ชื่อ account Github` ของตัวเอง เช่น `kengggg` ไว้ใน `/solutions`
3. ตั้งชื่อไฟล์ตามลำดับโจทย์ เช่น `01.py`, `02.php` และ `03.html`
4. สร้าง [Pull Request][2] มาที่ branch `main` ของ repository นี้
5. เมื่อทีมโอเพ่นดรีมได้รับแจ้ง Pull Request จะทำการ review เพื่อทำการดำเนินการสัมภาษณ์ต่อไป

[1]: https://www.opendream.co.th
[2]: https://docs.github.com/en/github/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/creating-a-pull-request
[3]: https://raw.githubusercontent.com/opendream/openteam/main/posts.json