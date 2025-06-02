![image](https://github.com/user-attachments/assets/faa87a4d-9e3f-4db7-a21d-421869319b77)

1. Установка SSH чтобы подключиться через Putty (т.к тебе надо копировать огромный ключ для гит)
sudo apt update
sudo apt install openssh-server
sudo systemctl enable ssh
sudo systemctl start ssh

2. Пробросы и настройка Putty (см рисунок 1 и 2)

3. Установка .NET
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-sdk-8.0

4. Git
ssh-keygen -t ed25519 -C "namek1305@gmail.com" - ключ потом enter два раза
eval "$(ssh-agent -s)"
ssh-add ~/.ssh/id_ed25519
cat ~/.ssh/id_ed25519.pub - содержание этого копируешь и вставляешь на гитхаб
https://github.com/settings/keys - куда надо вставить ключ

потом Git clone [ссылка SSH]
git clone git@github.com:namek1305/SiteForUbuntuServer.git ~/repo/MyWebApp

5. cd repo/MyWebApp мб ещё раз надо будет хз   или  cd SiteForUbuntuServer/MyWebApp                                                 !!!!! этот в крайнем случае !!!!!!!!!!! cd ~/repo/MyWebApp/SiteForUbuntuServer/MyWebApp

dotnet build
dotnet run --urls "http://0.0.0.0:5000"


Потом  винде на http://localhost:5000/ или http://localhost:5000/health или http://localhost:5000/api/animeseries или http://localhost:5000/api/animecharacters
И все должно работать


 rm -rf ~/SiteForUbuntuServer  - удаление папки


![image](https://github.com/user-attachments/assets/73b3919b-e579-4ffe-b454-0e9f5d82c999)
https://lh3.googleusercontent.com/fife/ALs6j_Ey39m4Hz9lIlBmVzNPr4Bclxq7pZojtkBQYqyHWI5eaPPMr8d2djbuO2Fusd4gSRicLlgKNNi_r_6Qo5pDLfw9NjDJx1ail3T0MMXo5_kHniASQbyONh8VyUcvHYCxsjExvHS3ND2jERcUA65TTFSJxYBx7UcnhbYfREzjGyTHjWPcq6t8Il32p-Xk3Qou8EHMywwGQTuHpZ_OYBdgLh8KkXg_Ic0enC02BKS6lzZuX0yFJZ7Fi1Ixs3U32ts0CLSoq0ALPn3S2YKEh2nLO_UWpT6g_5J3Yr4tyXAwKJhWTa92TG2XOBj8AkNLxxu8xy1UiWU3ruquZQYY1qqX00fDWbjafWv6zZiqXyI8KM4572HTdVUzY4vo_4XC9ovXCA-dXzdT65Gx0Hhp56qM2t4MlVFPk2KP5KF2jg5WKRZI5iSpRF2V_PMYlHa3-4qLHVCzvO-AXTtp5nwwdEpM-WaGh249SVxtGuJjZ3xSYt1DYJf2LYG6DQB5XM5rN5LunaCs55cu3fnv3wLE5wfvxfkn1HmmijfevDEcTrsFLAPZxvJEcajTa8xa2xaKFUo4rJ3tJGt-KLF3N7BC2_aDv2ZrZ66s76g_IeGD-JMoR_NJwnNXHb0evCS2EatlbfBRBf5uAU1wsZZ51WTg-6KP5iBKScLLgnGdWj5_3thb_4-u82OQSRjxsYaE5n3Vy7W9cAOusrfIUeSgy-Tv96D-it8EgtUD_hGLeQyPd2_9PxwJTDxX5hDwYCmxh4dZofAxipEtiBgQabzzg8bwccL1X6irZFrxXXZmeFu001ACvsTNo-d4U7ePlQxWSavJoFFxDi5wJAgxBA_YbAlboZ_V9auepp-Rqhzf1ewriOsgiIxd9Upt_a8Ef5c-YSyKUHKNTmR6icAo88AwiqHFI1jFAvU_RwnzSQwgv2ySAuIGhReaBHfoTU4q4ZNZK7S_1bllfiVdg5QjlvV_z1VoBM_DDrl2aZ_Smq0GhGVSGyrTxxit86Lci4WUPE4g-_78hE4a6_pqmtSVWdlZVBGVQBr3zjIauCCcLnvmx30UguIlk0MZjgtwQ5YBv0nYG74AbrcyiKin4_7fMT6wYpud5f767YFFCSSEMwIQzh49G3LOSO5VVcTOqV8hbzGeWfBFRSVk8qCMOdCyl7P3FETDn-v0FD5d9hqtC00ldBwhsls-4Q3b66WJM6soLI7aFaaFY-lp0ZC4fWz5PA7Q4oG4f0mHyZ319MKcdtM9KBYYBQCJWaJKjkkkknCyztiZDhGa0vnN832dF4LEuq19wH8=s570-w570-h43-n-k?authuser=0&cs=1&hl=ru-RU

если будет нужен nginx

sudo apt update
sudo apt install nginx


sudo nano /etc/nginx/sites-available/mywebapp


server {
    listen 80;
    server_name _;  # Можно заменить на твой домен или IP

    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }
}


или это как в примере было сделано
server {
    listen 80;
    location / {
        proxy_pass http://localhost:5000;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
        proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
        proxy_set_header X-Forwarded-Proto $scheme;
    }
}

sudo ln -s /etc/nginx/sites-available/mywebapp /etc/nginx/sites-enabled/

sudo nginx -t

sudo systemctl restart nginx

dotnet run --urls "http://0.0.0.0:5000"


Далее у тебя будет не твоя страница а дефолт nginx

sudo rm /etc/nginx/sites-enabled/default
sudo ln -s /etc/nginx/sites-available/mywebapp /etc/nginx/sites-enabled/
sudo nginx -t
sudo systemctl reload nginx


sudo systemctl reload nginx

dotnet run --urls "http://0.0.0.0:5000"

http://127.0.0.1:8080

Должно работать


Получается у тебя сайт доступен по порту 5000 - это кестрель (встроенный .NET)
А 8080 - nginx

http://localhost:80/health или http://localhost:90/api/animeseries или http://localhost:80/api/animecharacters

для тестов 
curl http://localhost:80/health
curl http://localhost:5050/health
history вывод команд всех для показа крутоты
