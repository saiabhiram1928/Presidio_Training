import re
from datetime import datetime, date
import pandas as pd
from fpdf import FPDF

class Employee:
    def __init__(self, name, dob, phone, email):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email
        self.age = self.calculate_age(dob)
    
    @staticmethod
    def calculate_age(dob):
        dob = datetime.strptime(dob, '%Y-%m-%d')
        today = date.today()
        age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
        return age
    
    @staticmethod
    def validate_name(name):
        return bool(re.match(r"^[A-Za-z\s]+$", name))
    
    @staticmethod
    def validate_dob(dob):
        try:
            datetime.strptime(dob, '%Y-%m-%d')
            return True
        except ValueError:
            return False
    
    @staticmethod
    def validate_phone(phone):
        return bool(re.match(r"^\d{10}$", phone))
    
    @staticmethod
    def validate_email(email):
        return bool(re.match(r"^[\w\.-]+@[\w\.-]+\.\w+$", email))
    
    @classmethod
    def from_input(cls):
        while True:
            name = input("Enter name: ")
            if cls.validate_name(name):
                break
            else:
                print("Invalid name. Please enter alphabets and spaces only.")
        
        while True:
            dob = input("Enter date of birth (YYYY-MM-DD): ")
            if cls.validate_dob(dob):
                break
            else:
                print("Invalid date of birth. Please enter in YYYY-MM-DD format.")
        
        while True:
            phone = input("Enter phone number: ")
            if cls.validate_phone(phone):
                break
            else:
                print("Invalid phone number. Please enter a 10-digit number.")
        
        while True:
            email = input("Enter email: ")
            if cls.validate_email(email):
                break
            else:
                print("Invalid email. Please enter a valid email address.")
        
        return cls(name, dob, phone, email)

class EmployeeManager:
    def __init__(self):
        self.employees = []
    
    def add_employee(self, employee):
        self.employees.append(employee)
    
    def save_to_text(self, filename):
        with open(filename, 'w') as file:
            for emp in self.employees:
                file.write(f"Name: {emp.name}, DOB: {emp.dob}, Phone: {emp.phone}, Email: {emp.email}, Age: {emp.age}\n")
    
    def save_to_excel(self, filename):
        data = {
            "Name": [emp.name for emp in self.employees],
            "DOB": [emp.dob for emp in self.employees],
            "Phone": [emp.phone for emp in self.employees],
            "Email": [emp.email for emp in self.employees],
            "Age": [emp.age for emp in self.employees]
        }
        df = pd.DataFrame(data)
        df.to_excel(filename, index=False)
    
    def save_to_pdf(self, filename):
        pdf = FPDF()
        pdf.add_page()
        pdf.set_font("Arial", size=12)
        for emp in self.employees:
            pdf.cell(200, 10, txt=f"Name: {emp.name}, DOB: {emp.dob}, Phone: {emp.phone}, Email: {emp.email}, Age: {emp.age}", ln=True)
        pdf.output(filename)
    
    def bulk_read_from_excel(self, filename):
        df = pd.read_excel(filename)
        for index, row in df.iterrows():
            emp = Employee(row['Name'], row['DOB'], row['Phone'], row['Email'])
            self.add_employee(emp)

def main():
    manager = EmployeeManager()
    
    while True:
        print("\n1. Add Employee")
        print("\n2. Save to Text File")
        print("\n3. Save to Excel File")
        print("\n4. Save to PDF File")
        print("\n5. Bulk Read from Excel")
        print("\n6. Exit")
        choice = input("Enter your choice: ")

        if choice == '1':
            emp = Employee.from_input()
            manager.add_employee(emp)
        elif choice == '2':
            filename = input("Enter filename (with .txt extension): ")
            manager.save_to_text(filename)
        elif choice == '3':
            filename = input("Enter filename (with .xlsx extension): ")
            manager.save_to_excel(filename)
        elif choice == '4':
            filename = input("Enter filename (with .pdf extension): ")
            manager.save_to_pdf(filename)
        elif choice == '5':
            filename = input("Enter Excel filename to read from: ")
            manager.bulk_read_from_excel(filename)
        elif choice == '6':
            break
        else:
            print("Invalid choice. Please enter a number between 1 and 6.")

if __name__ == "__main__":
    main()
