
# 📦 Smart Health Monitoring System – Dockerized Project

## 🩺 Overview

The **Smart Health Monitoring System** is a modular, containerized application developed in **C#** that utilizes biometric sensors to collect real-time health data. The system performs **machine learning-based anomaly detection**, generates daily reports, and offers a warning system for potential health risks. It also tracks health data over time for long-term monitoring.

This project uses **Docker** to containerize all essential components and ensures smooth multi-container deployment using **Docker Compose** or **Kubernetes**.

---

## 🐳 Why Docker?

Docker allows us to:

* Standardize development environments
* Easily deploy across multiple platforms
* Run independent containers for API, database, UI, and admin tools
* Ensure scalability and maintainability

Each component of this system runs in its own isolated container, ensuring efficient resource management and easy maintenance.

---

## 🧩 Project Architecture

The system is composed of the following containers:

```
+----------------------------+
|   SmartHealthSystem API   | <-- C# ASP.NET Web API
+----------------------------+
            |
            v
+----------------------------+      +-------------------------+
|          MySQL            | <--->|  phpMyAdmin (optional)  |
+----------------------------+      +-------------------------+
            |
            v
+----------------------------+
|         Frontend          | <-- HTML/CSS/JS web interface
+----------------------------+
```

---

## 🚀 Docker Images

You can pull the pre-built images from DockerHub using the following commands:

```bash
docker pull secode/dockercon:smarthealtsystemApi    # Backend API (C#)
docker pull secode/dockercon:mysqlcon               # MySQL Database
docker pull secode/dockercon:pma                    # phpMyAdmin interface
docker pull secode/dockercon:frontend               # Frontend interface
```

### 🧠 1. `smarthealtsystemApi`

* Built with ASP.NET Core in C#
* Exposes REST endpoints to receive and process biometric health data
* Integrates machine learning for health risk prediction

### 🗄️ 2. `mysqlcon`

* Runs a MySQL server
* Stores all biometric data, user details, and historical health information
* Uses persistent storage via Docker volume

### 🧰 3. `pma`

* phpMyAdmin interface for easy database management
* Useful for testing, development, and administration

### 💻 4. `frontend`

* Simple web interface for displaying health status and reports
* Communicates with the API to display alerts and graphs

---

## 📂 DockerHub Profile

All images are hosted on DockerHub under the user: [`secode`](https://hub.docker.com/u/secode)

* ✅ Lightweight and production-ready
* 🔄 Frequently updated
* 🐧 Compatible with Linux & Windows containers

---

## ⚙️ Getting Started

### 🔧 Prerequisites

* Docker installed
* Docker Compose (optional)
* Internet access to pull images

### 📦 Pulling the Containers

```bash
docker pull secode/dockercon:frontend
docker pull secode/dockercon:pma
docker pull secode/dockercon:mysqlcon
docker pull secode/dockercon:smarthealtsystemApi
```

### 🔄 Running with Docker Compose

Create a `docker-compose.yml`:

```yaml
version: "3.8"
services:
  mysql:
    image: secode/dockercon:mysqlcon
    container_name: mysql
    restart: always
    environment:
      MYSQL_ROOT_PASSWORD: test123
      MYSQL_DATABASE: healthdata
    ports:
      - "3306:3306"

  pma:
    image: secode/dockercon:pma
    container_name: phpmyadmin
    ports:
      - "8080:80"
    environment:
      PMA_HOST: mysql
    depends_on:
      - mysql

  backend:
    image: secode/dockercon:smarthealtsystemApi
    container_name: api
    ports:
      - "5000:80"
    depends_on:
      - mysql

  frontend:
    image: secode/dockercon:frontend
    container_name: web
    ports:
      - "3000:80"
    depends_on:
      - backend
```

Run the containers:

```bash
docker-compose up -d
```

---

# 🛠️ Database and Table Creation

You can manually create your database and the required table by pasting the following SQL script into **phpMyAdmin > SQL** tab:

```sql
CREATE DATABASE IF NOT EXISTS healthdb;

USE healthdb;

CREATE TABLE IF NOT EXISTS health_data (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    heart_rate INT,
    blood_pressure VARCHAR(20),
    temperature FLOAT,
    recorded_at DATETIME
);
```
## 📈 Features

* ✅ Real-time health data monitoring
* 🧠 Machine learning-based abnormality detection
* 📝 Daily report generation
* 🔔 Alerts for risky conditions
* 📊 Web interface and API access
* 🛠️ Fully containerized for deployment on any platform

---

## 🔒 Security

* API secured via standard authentication mechanisms
* MySQL access restricted to internal services
* Sensitive data stored securely in environment variables

---

## 🧪 Future Improvements

* Add authentication for frontend access
* Enhance machine learning model with real-world data
* Kubernetes Helm chart for production deployment
* Add Prometheus & Grafana monitoring stack

---

## 👨‍💻 Author

* 🐳 DockerHub: [https://hub.docker.com/u/secode](https://hub.docker.com/u/secode)



# 📦 Akıllı Sağlık İzleme Sistemi – Docker Projesi

## 🩺 Genel Bakış

**Akıllı Sağlık İzleme Sistemi**, biyometrik sensörleri kullanarak gerçek zamanlı sağlık verilerini toplayan modüler ve konteynerleştirilmiş bir uygulamadır. Bu sistem, **makine öğrenimi tabanlı anormallik tespiti** gerçekleştirir, günlük raporlar üretir ve potansiyel sağlık risklerine karşı uyarı sistemi sunar. Ayrıca, sağlık verilerinin zaman içindeki değişimini izleyerek uzun vadeli değerlendirme sağlar.

Proje, tüm temel bileşenleri konteynerleştirmek için **Docker** kullanır ve **Docker Compose** ya da **Kubernetes** ile çoklu konteyner dağıtımı sağlar.

---

## 🐳 Neden Docker?

Docker bize şunları sağlar:

* Geliştirme ortamlarının standartlaştırılması
* Farklı platformlarda kolay dağıtım
* API, veritabanı, kullanıcı arayüzü ve yönetim araçları için bağımsız konteynerler
* Ölçeklenebilirlik ve sürdürülebilirlik

Bu sistemin her bileşeni kendi izole konteynerinde çalışır ve böylece kaynaklar verimli kullanılır, bakım kolaylaşır.

---

## 🧩 Proje Mimarisi

Sistem aşağıdaki konteynerlerden oluşur:

```
+----------------------------+
|   SmartHealthSystem API   | <-- C# ASP.NET Web API
+----------------------------+
            |
            v
+----------------------------+      +-------------------------+
|          MySQL            | <--->|  phpMyAdmin (isteğe bağlı)|
+----------------------------+      +-------------------------+
            |
            v
+----------------------------+
|         Arayüz            | <-- HTML/CSS/JS web arayüzü
+----------------------------+
```

---

## 🚀 Docker İmajları

Aşağıdaki komutları kullanarak DockerHub üzerinden hazır imajları çekebilirsiniz:

```bash
docker pull secode/dockercon:smarthealtsystemApi    # Backend API (C#)
docker pull secode/dockercon:mysqlcon               # MySQL Veritabanı
docker pull secode/dockercon:pma                    # phpMyAdmin Arayüzü
docker pull secode/dockercon:frontend               # Web Arayüz
```

### 🧠 1. `smarthealtsystemApi`

* ASP.NET Core ile C# dilinde yazılmıştır
* Biyometrik sağlık verilerini alıp işleyen REST API sağlar
* Sağlık riski tahmini için makine öğrenimi entegrasyonu

### 🗄️ 2. `mysqlcon`

* MySQL sunucusunu çalıştırır
* Tüm sağlık verilerini, kullanıcı bilgilerini ve geçmiş kayıtları tutar
* Kalıcı veri depolama için Docker volume kullanır

### 🧰 3. `pma`

* Veritabanı yönetimi için phpMyAdmin arayüzü
* Test, geliştirme ve yönetim için kullanışlıdır

### 💻 4. `frontend`

* Sağlık durumunu ve raporları gösteren basit web arayüzü
* API ile iletişim kurarak uyarılar ve grafikler sunar

---

## 📂 DockerHub Profili

Tüm imajlar DockerHub üzerinde şu kullanıcı altında barındırılmaktadır: [`secode`](https://hub.docker.com/u/secode)

* ✅ Hafif ve üretime hazır
* 🔄 Düzenli olarak güncellenir
* 🐧 Linux & Windows konteynerlerle uyumlu

---

## ⚙️ Başlarken

### 🔧 Gereksinimler

* Docker kurulu olmalı
* Docker Compose (isteğe bağlı)
* İmajları çekmek için internet bağlantısı

### 📦 Konteynerleri Çekme

```bash
docker pull secode/dockercon:frontend
docker pull secode/dockercon:pma
docker pull secode/dockercon:mysqlcon
docker pull secode/dockercon:smarthealtsystemApi
```

### 🔄 Docker Compose ile Çalıştırma

Bir `docker-compose.yml` dosyası oluşturun:

```yaml
version: "3.8"
services:
  mysql:
    image: secode/dockercon:mysqlcon
    container_name: mysql
    restart: always
    environment:
      MYSQL_ROOT_PASSWORD: test123
      MYSQL_DATABASE: healthdata
    ports:
      - "3306:3306"

  pma:
    image: secode/dockercon:pma
    container_name: phpmyadmin
    ports:
      - "8080:80"
    environment:
      PMA_HOST: mysql
    depends_on:
      - mysql

  backend:
    image: secode/dockercon:smarthealtsystemApi
    container_name: api
    ports:
      - "5000:80"
    depends_on:
      - mysql

  frontend:
    image: secode/dockercon:frontend
    container_name: web
    ports:
      - "3000:80"
    depends_on:
      - backend
```

Konteynerleri başlatın:

```bash
docker-compose up -d
```

---

### 🛠️ Veritabanı ve Tablo Oluşturma

Aşağıdaki SQL sorgusunu **phpMyAdmin > SQL** sekmesine yapıştırarak veritabanınızı ve gerekli tabloyu manuel olarak oluşturabilirsiniz:

```sql
CREATE DATABASE IF NOT EXISTS healthdb;

USE healthdb;

CREATE TABLE IF NOT EXISTS health_data (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    heart_rate INT,
    blood_pressure VARCHAR(20),
    temperature FLOAT,
    recorded_at DATETIME
);
```

### 📌 Açıklamalar

* `CREATE DATABASE IF NOT EXISTS healthdb;`:
  `healthdb` adlı veritabanı daha önce yoksa oluşturur. Bu adım veritabanının çakışmasını engeller.

* `USE healthdb;`:
  Oluşturulan/verilen veritabanını aktif olarak seçer.

* `CREATE TABLE IF NOT EXISTS health_data (...);`:
  Sağlık verilerini saklayacak olan `health_data` tablosunu oluşturur. Tablo sütunları şunlardır:

| Sütun Adı        | Veri Tipi   | Açıklama                                    |
| ---------------- | ----------- | ------------------------------------------- |
| `id`             | INT         | Otomatik artan, her kayıt için benzersiz ID |
| `user_id`        | INT         | Veriyi gönderen kullanıcının kimliği        |
| `heart_rate`     | INT         | Kalp atış hızı (bpm)                        |
| `blood_pressure` | VARCHAR(20) | Kan basıncı (örnek: 120/80)                 |
| `temperature`    | FLOAT       | Vücut sıcaklığı (°C)                        |
| `recorded_at`    | DATETIME    | Verinin kaydedildiği tarih ve saat          |

Bu adımlar tamamlandığında sistem sağlık verilerini bu tabloya kaydedebilecek hale gelir.

---


## 📈 Özellikler

* ✅ Gerçek zamanlı sağlık verisi izleme
* 🧠 Makine öğrenimi ile anormallik tespiti
* 📝 Günlük rapor üretimi
* 🔔 Riskli durumlar için uyarılar
* 📊 Web arayüzü ve API erişimi
* 🛠️ Tüm bileşenler konteynerleştirilmiştir

---

## 🔒 Güvenlik

* API, standart kimlik doğrulama yöntemleriyle korunur
* MySQL erişimi yalnızca dahili servislerle sınırlıdır
* Hassas veriler ortam değişkenlerinde saklanır

---

## 🧪 Gelecekteki Geliştirmeler

* Web arayüzüne kullanıcı kimlik doğrulama eklenmesi
* Makine öğrenimi modelinin gerçek verilerle geliştirilmesi
* Üretim ortamı için Kubernetes Helm chart
* Prometheus & Grafana ile izleme sisteminin entegrasyonu

---

## 👨‍💻 Geliştirici

* 🐳 DockerHub: [https://hub.docker.com/u/secode](https://hub.docker.com/u/secode)


