package controller.commands;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

import javax.swing.filechooser.FileSystemView;

import controller.commandExcution;
import model.DirectoryData;
import view.CommandResult;

public class DIR implements commandExcution {
	CommandResult commandResult;
	DirectoryData directoryData;
	File path;
	public DIR(CommandResult commandResult,DirectoryData directoryData) {
		this.commandResult=commandResult;
		this.directoryData=directoryData;
	}
	@Override
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		synchronizeFile();
		movePath(command);
		if(path.exists()) {
			if(path.isDirectory())
				findDirectoryData();
			else if(path.isFile())
				findFileData();
		}
		else {
			commandResult.showDiskData(getPath(path));
			System.out.println("파일을 찾을 수 없습니다.");
		}
	}
	private void synchronizeFile() {
		path=new File(directoryData.getDirectory());
	}
	private void movePath(String extraLine) {
		String extraCommand=extraLine.trim();
		if(extraCommand.contains(":"))//절대경로 이동
			moveToAbsolutePath(extraCommand);
		else//상대경로 이동
			moveToRelativePath(extraCommand);
	}
	private void moveToAbsolutePath(String filePath) {
		path=new File(filePath);
			
	}
	private void moveToRelativePath(String filePath) {
		path=new File(path.getPath()+"\\"+filePath);
		path=new File(getPath(path));
	}
	private void findDirectoryData() {
		File[] files=path.listFiles();
		int directoryCount=0;
		int fileCount=0;
		long fileByte=0;
		commandResult.showDiskData(getPath(path));
		if(getPath(path.getParentFile())!="") {
			System.out.println(path.getParentFile());
			directoryCount+=2;
			addCurrentAndParentData();
		}
		for(int count=0;count<files.length;count++) {
			if(!files[count].isHidden()) {
				Date lastModified=new Date(files[count].lastModified());
				if(files[count].isDirectory()) {
					directoryCount++;
					commandResult.showDirectoryData(lastModified,"<DIR>",files[count].getName());
				}
				else if(files[count].isFile()) {
					fileCount++;
					fileByte+=files[count].length();
					commandResult.showFileData(lastModified, files[count].length(), files[count].getName());
				}
			}
		}
		commandResult.showDirectoryByte(directoryCount, fileCount, fileByte, path.getUsableSpace());
	}
	private void addCurrentAndParentData() {
		Date lastModified=new Date(path.lastModified());
		commandResult.showDirectoryData(lastModified,"<DIR>",".");
		lastModified=new Date(path.getParentFile().lastModified());
		commandResult.showDirectoryData(lastModified,"<DIR>","..");
	}
	private void findFileData() {
		commandResult.showDiskData(getPath(path.getParentFile()));
		Date lastModified=new Date(path.lastModified());
		commandResult.showFileData(lastModified, path.length(), path.getName());
		commandResult.showDirectoryByte(1, 0, path.length(), path.getUsableSpace());
	}
	private String getPath(File file) {
		try {
			String canonicalPath=file.getCanonicalPath();
			return canonicalPath;
		}
		catch(Exception e) {
			return "";
		}
	}
}
