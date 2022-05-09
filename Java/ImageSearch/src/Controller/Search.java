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
	public Search() {
		mainFrame=new MainFrame();
		imageDAO=new ImageDAO();
	}
	public void LoadFrame() {
		mainFrame.ShowForm();
		mainFrame.SetMainForm();
		mainFrame.addSearchButtonListner(new SearchButtonListener());
		mainFrame.addTextMouseListner(new SearchFieldMouseListener());
		mainFrame.addTextKeyListner(new SearchFieldKeyListener());
		mainFrame.addBackButtonListner(new BackButtonListener());
	}
	
	private void SetTextAndClicked(String text,boolean isClicked) {
		mainFrame.searchField.setText(text);
		mainFrame.isClicked=isClicked;
	}
	
	private class SearchFieldMouseListener implements MouseListener{
		public void mousePressed(MouseEvent e) {
			if(mainFrame.isClicked==Constant.isNotClick) {
				SetTextAndClicked("",Constant.isClick);
			}
		}
		public void mouseEntered(MouseEvent e) {	
		}
		public void mouseReleased(MouseEvent e) {
		}
		public void mouseClicked(MouseEvent e) {	
		}
		public void mouseExited(MouseEvent e) {
		}
	}
	private class SearchFieldKeyListener implements KeyListener{
		public void keyPressed(KeyEvent e) {
			if(mainFrame.isClicked==Constant.isNotClick) {
				SetTextAndClicked("",Constant.isClick);
			}
			if(e.getKeyChar()=='\n') {
				if(!mainFrame.searchField.getText().equals("")) {
					SetTextAndClicked("검색어가 비어있습니다.",Constant.isNotClick);
				}
				else {//내용 있을 때 검색 시
					imageDAO.getImage(mainFrame.searchField.getText());
					mainFrame.SetResultForm();
				}
			}
		}
		public void keyTyped(KeyEvent e) {	
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
				imageDAO.getImage(mainFrame.searchField.getText());
				mainFrame.SetResultForm();
			}
		}
	}
	private class BackButtonListener implements ActionListener{
		public void actionPerformed(ActionEvent e) {
			mainFrame.SetMainForm();
		}
	}
	private void LoadResultForm() {
		mainFrame.searchField.getText();
		mainFrame.SetResultForm();
	}
}
