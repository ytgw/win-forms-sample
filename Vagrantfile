# -*- mode: ruby -*-
# vi: set ft=ruby :

Vagrant.configure("2") do |config|
  # Windows 11 の Box（GusztavVargadr 氏作成の軽量・自動セットアップ済み評価版）
  config.vm.box = "gusztavvargadr/windows-11"

  config.vm.provision "shell", inline: <<-SHELL
    Write-Host "Hello from Guest Windows VM!"
    Set-ExecutionPolicy Unrestricted -Scope Process -Force

    $wingetPath = Resolve-Path "C:\\Program Files\\WindowsApps\\Microsoft.DesktopAppInstaller_*_x64__8wekyb3d8bbwe\\winget.exe" | Select-Object -ExpandProperty Path -Last 1

    & $wingetPath install --exact --silent --source winget --accept-package-agreements --accept-source-agreements --id Microsoft.DotNet.SDK.10
    & $wingetPath install --exact --silent --source winget --accept-package-agreements --accept-source-agreements --id Microsoft.VisualStudio.Community
  SHELL

  # VirtualBox の個別スペック設定
  config.vm.provider "virtualbox" do |vb|
    # Windows 11 は画面操作が基本のため GUI を有効化
    vb.gui = true

    # Windows 11 動作に必要な最低スペック（メモリ4GB以上、2コア以上）
    vb.memory = "4096"
    vb.cpus = 4

    # パフォーマンス向上（2D/3DアクセラレーションとVRAM増量）
    vb.customize ["modifyvm", :id, "--vram", "128"]
    vb.customize ["modifyvm", :id, "--graphicscontroller", "vboxsvga"]

    # クリップボード共有（双方向）
    vb.customize ["modifyvm", :id, "--clipboard-mode", "bidirectional"]
  end

  # WinRMでのログイン待機タイムアウトを延長（Windowsの起動は重いため）
  config.winrm.retry_limit = 30
  config.winrm.retry_delay = 10
end
