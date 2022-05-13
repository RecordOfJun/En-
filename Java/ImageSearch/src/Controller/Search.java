package Controller;
import Utility.Constant;
import Model.*;
import java.awt.event.*;
import java.awt.event.KeyEvent;
import java.awt.event.MouseEvent;

import View.MainFrame;

public class Search{
	MainFrame mainFrame;
	ImageDAO imageDAO;
	RecordDAO recordDAO;
	public Search() {
		mainFrame=new MainFrame();
		imageDAO=new ImageDAO();
		recordDAO=new RecordDAO();
	}
	public void LoadFrame() {
		mainFrame.ShowForm();
		mainFrame.SetMainForm();
		mainFrame.addSearchButtonListner(new SearchButtonListener());
		mainFrame.addTextMouseListner(new SearchFieldMouseListener());
		mainFrame.addTextKeyListner(new SearchFieldKeyListener());
		mainFrame.addBackButtonListner(new BackButtonListener());
		mainFrame.addRecordButtonListner(new RecordButtonListener());
		mainFrame.addDeleteButtonListner(new DeleteButtonListener());
	}
	
	private void SetTextAndClicked(String text,boolean isClicked) {
		mainFrame.searchField.setText(text);
		mainFrame.isClicked=isClicked;
	}
	
	public class SearchFieldMouseListener extends MouseAdapter{
		public void mousePressed(MouseEvent e) {
			if(mainFrame.isClicked==Constant.isNotClick) {
				SetTextAndClicked("",Constant.isClick);
			}
			System.out.println("A");
		}
	}
	private class SearchFieldKeyListener implements KeyListener{
		public void keyPressed(KeyEvent e) {
		}
		public void keyTyped(KeyEvent e) {	
			if(mainFrame.isClicked==Constant.isNotClick) {
				SetTextAndClicked("",Constant.isClick);
			}
			if(e.getKeyChar()=='\n') {
				if(mainFrame.searchField.getText().equals("")) {
					SetTextAndClicked("검색어가 비어있습니다.",Constant.isNotClick);
				}
				else {//내용 있을 때 검색 시
					LoadResultForm();
				}
			}
		}
		public void keyReleased(KeyEvent e) {
		}
	}
	private class SearchButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			if(mainFrame.isClicked==Constant.isNotClick||mainFrame.searchField.getText().equals("")) {
				SetTextAndClicked("검색어가 비어있습니다.",Constant.isNotClick);
			}
			else {//내용 있을 때 검색 시
				LoadResultForm();
			}
		}
	}
	private class BackButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			mainFrame.SetMainForm();
		}//
	}
	private void LoadResultForm() {
		String text=mainFrame.searchField.getText();
		recordDAO.InsertRecord(text);
		mainFrame.SetResultForm(imageDAO.getImage(text));
	}
	private class RecordButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			mainFrame.SetRecordForm(recordDAO.SelectRecord());
		}
	}
	private class DeleteButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			recordDAO.DeleteRecord();
			mainFrame.SetRecordForm(recordDAO.SelectRecord());
		}
	}
}
