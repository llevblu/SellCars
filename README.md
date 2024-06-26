# Setup-Car-Sell
# Аннотация
Это приложение представляет собой информационную систему для управления клиентами и заказами с использованием базы данных PostgreSQL. Система предоставляет функции добавления, редактирования и удаления клиентов, а также отслеживания заказов и доставки.

# Введение
## Основные возможности
- Управление клиентами: добавление, редактирование и удаление записей клиентов.
- Управление заказами: создание и отслеживание заказов.
- Интеграция с базой данных PostgreSQL.
- Безопасное хранение номеров телефонов.
- Генерация отчетов и представлений данных.

# Назначение и условия применения
Эта информационная система предназначена для использования в компаниях, занимающихся логистикой и управлением заказами. Она позволяет оптимизировать процесс обработки заказов и управления клиентами. Условия применения включают наличие установленной базы данных PostgreSQL и среды выполнения .NET Core для запуска приложения.

# Установка
1. Установите [Docker Desktop](https://www.docker.com/products/docker-desktop) на вашем компьютере.
2. Склонируйте репозиторий проекта:
   git clone (https://github.com/llevblu/Setup-Car-Sell/)
   cd yourproject
3. Заполните скрипт инициализации базы данных init_db.sql необходимыми таблицами и данными.
4. Создайте и настройте файл docker-compose.yml.
5. Создайте и настройте Dockerfile для вашего приложения на C#.
6. Постройте и запустите контейнеры Docker
   docker-compose up -d
7. Проверьте журналы для отладки в случае ошибок:
   docker-compose logs

# Описание операций
1. Добавление клиента: форма добавления клиента позволяет ввести необходимые данные и автоматически присвоить идентификатор.
2. Удаление клиента: форма удаления клиента позволяет удалить запись клиента по идентификатору.
3. Редактирование клиента: форма редактирования клиента позволяет изменить данные существующего клиента.
4. Просмотр клиентов: данные о клиентах выводятся в DataGridView для удобного просмотра и фильтрации.

# Термины и сокращения
-----------------------------------------------------------------------------------------------------------------------
|Термин	                | Сокращение          |	Описание                                                              |
-----------------------------------------------------------------------------------------------------------------------
|Клиент		              |                     | Физическое или юридическое лицо, являющееся заказчиком услуг.         |
|Заказ		              |                     | Запрос на выполнение услуги или поставку товара.                      |
|База данных	          | БД	                | Организованное хранилище данных.                                      |
|Идентификатор	        | ID	                | Уникальный номер, присвоенный записи в базе данных.                   |
|Docker		              |                     | Платформа для разработки, доставки и запуска приложений в контейнерах.|
|PostgreSQL		          |                     | Система управления базами данных.                                     |
|.NET Core		          |                     | Кроссплатформенная среда выполнения для приложений.                   |
-----------------------------------------------------------------------------------------------------------------------
