# Variables
COMPOSE_PROJECT_NAME=fov
DOCKER_IMAGE=fovpresentation
DOCKERFILE_PATH=src/FOV.Presentation/Dockerfile
DOCKER_COMPOSE_FILE=docker-compose.yml
D

# Targets
.PHONY: all build run remove

all: remove build run

# Remove containers and volumes
remove:
	@echo "Stopping and removing containers and volumes..."
	docker-compose down -v

# Build the Docker image
build:
	@echo "Building Docker image..."
	docker build -t $(DOCKER_IMAGE) -f $(DOCKERFILE_PATH) .

# Run containers using docker-compose
run:
	@echo "Starting containers..."
	docker-compose --project-name $(COMPOSE_PROJECT_NAME) up -d

commit:
	@echo "Add New code update...."
	docker-compose up -d --build
