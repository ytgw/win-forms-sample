FROM ubuntu:26.04

# ロケールのセットアップ
RUN DEBIAN_FRONTEND=noninteractive \
    apt-get update \
    && apt-get install -y locales \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/* \
    && echo "en_US.UTF-8 UTF-8" >> /etc/locale.gen \
    && locale-gen en_US.UTF-8

# 必要なパッケージのインストールとクリーンアップ
RUN DEBIAN_FRONTEND=noninteractive \
    apt-get update \
    && apt-get install -y sudo bash-completion git dotnet-sdk-10.0 \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

# ユーザー名とUIDの定義
ARG USERNAME=user
ARG USER_UID

# 同じUIDユーザーがいたら削除
RUN userdel -r $(getent passwd $USER_UID | cut -d: -f1) || true

# グループとユーザーを作成し、sudoグループに追加
RUN useradd --uid $USER_UID -m -s /bin/bash $USERNAME \
    && usermod -aG sudo $USERNAME \
    && echo "$USERNAME ALL=(ALL) NOPASSWD:ALL" >> /etc/sudoers.d/$USERNAME

# 作成したユーザーに切り替え
USER $USERNAME
ARG WORKDIR
RUN mkdir $WORKDIR
WORKDIR $WORKDIR
