# Justfile

# Build both containers for the Pi architecture
build:
    docker build -t furbo-body -f services/body/Dockerfile ./services/body
    docker build -t furbo-eyes -f services/eyes/Dockerfile ./services/eyes

# Push code to the Pi (rsync for fast dev cycles)
sync ip:
    rsync -avz --exclude 'target' ./ pi@{{ip}}:~/furbo-bot

# SSH into the Pi and restart containers
deploy ip: (sync ip)
    ssh pi@{{ip}} "cd ~/furbo-bot && docker-compose -f deploy/docker-compose.yml up -d --build"

# Run the vision service locally for testing
dev-eyes:
    cd services/eyes && python3 main.py