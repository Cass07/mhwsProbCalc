using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mhwsProbCalc
{
    public partial class Form1 : Form
    {
        private List<ItemEntry> itemEntries = new List<ItemEntry>();
        private int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // 새 항목 추가
            ItemEntryForm entryForm = new ItemEntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                ItemEntry newItem = new ItemEntry(currentIndex, entryForm.ItemName,
                    entryForm.WeightFactor, entryForm.ItemCount);

                itemEntries.Add(newItem);
                Console.WriteLine($"항목 추가: {newItem.getName()} - 개수: {newItem.getCount()} - 가중치: {newItem.getWeightFactor()}");
                currentIndex++;
                UpdateListBox();
            }
        }

        private void ListBoxItems_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex != -1)
            {
                // 선택된 항목 수정
                int selectedIndex = listBoxItems.SelectedIndex;
                ItemEntry selectedItem = itemEntries[selectedIndex];

                ItemEntryForm entryForm = new ItemEntryForm(selectedItem);
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    selectedItem.updateEntry(entryForm.ItemCount, entryForm.ItemName, entryForm.WeightFactor);
                    UpdateListBox();
                }
            }
        }

        private void UpdateListBox()
        {
            listBoxItems.Items.Clear();
            foreach (ItemEntry item in itemEntries)
            {
                listBoxItems.Items.Add($"{item.getName()} - 개수: {item.getCount()} - 가중치: {item.getWeightFactor()}");
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (itemEntries.Count == 0)
            {
                MessageBox.Show("항목을 하나 이상 추가해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int trialCount = (int)numericTrials.Value;
                Items items = new Items(itemEntries.ToArray());
                AbstractCalculator calculator = new IndependentTrialsCalc();
                ResultEntry[] results = calculator.Calculate(items, trialCount);
                foreach(ResultEntry result in results)
                {
                    Console.WriteLine($"{result.getName()} - {result.getRate()}");
                }

                // 결과 창 표시
                ResultForm resultForm = new ResultForm(results);

                resultForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"계산 중 오류가 발생했습니다: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void BtnCalculate2_Click(object sender, EventArgs e)
        {
            if (itemEntries.Count == 0)
            {
                MessageBox.Show("항목을 하나 이상 추가해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int trialCount = (int)numericTrials.Value;
                Items items = new Items(itemEntries.ToArray());
                AbstractCalculator calculator = new DependentTrialsCalc();
                ResultEntry[] results = calculator.Calculate(items, trialCount);
                foreach (ResultEntry result in results)
                {
                    Console.WriteLine($"{result.getName()} - {result.getRate()}");
                }

                // 결과 창 표시
                ResultForm resultForm = new ResultForm(results);

                resultForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"계산 중 오류가 발생했습니다: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
