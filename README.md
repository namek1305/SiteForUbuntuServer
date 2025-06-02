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
ssh-keygen -t ed25519 -C "твой_email@пример.com" - ключ
eval "$(ssh-agent -s)"
ssh-add ~/.ssh/id_ed25519
cat ~/.ssh/id_ed25519.pub - содержание этого копируешь и вставляешь на гитхаб

потом Git clone [ссылка SSH]

5. cd repo/MyWebApp (туда где .cs .csproj

dotnet build
dotnet run --urls "http://0.0.0.0:5000"


Потом  винде на http://localhost:5000/ 
И все должно работать


 rm -rf ~/SiteForUbuntuServer  - удаление папки


![image](https://github.com/user-attachments/assets/23187891-b993-4c3f-b38a-34d94b29e65f)


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

Должгл работать


Получается у тебя сайт доступен по порту 5000 - это кестрель (встроенный .NET)
А 8080 - nginx
