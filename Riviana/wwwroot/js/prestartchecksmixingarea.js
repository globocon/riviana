// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(document).on('click', '#btnPrintPreCheckList', function () {
//    $('.order-checkbox').prop('checked', this.checked);
//});


$(function () {

    // Function to replace form controls with text equivalents before rendering
    // Convert controls to plain text
    function convertControlsToText(originalContainer) {
        // Clone the container to avoid modifying the live DOM
        const clone = originalContainer.cloneNode(true);

        // Remove buttons and elements with class 'no-print'
        clone.querySelectorAll('button, .no-print').forEach(el => el.remove());

        // Handle each input, select, and textarea by referring to the original element
        const originalInputs = originalContainer.querySelectorAll('input');
        const cloneInputs = clone.querySelectorAll('input');
        cloneInputs.forEach((input, i) => {
            const original = originalInputs[i];
            const span = document.createElement('span');
            span.textContent = original?.value || '';
            span.style.display = 'inline-block';
            span.style.minWidth = original.offsetWidth + 'px';
            span.style.borderBottom = '1px dotted #999';
            input.replaceWith(span);
        });

        const originalSelects = originalContainer.querySelectorAll('select');
        const cloneSelects = clone.querySelectorAll('select');
        cloneSelects.forEach((select, i) => {
            const original = originalSelects[i];
            const selectedText = original?.options[original.selectedIndex]?.text || '';
            const span = document.createElement('span');
            span.textContent = selectedText;
            span.style.display = 'inline-block';
            span.style.minWidth = original.offsetWidth + 'px';
            span.style.borderBottom = '1px dotted #999';
            select.replaceWith(span);
        });

        const originalTextareas = originalContainer.querySelectorAll('textarea');
        const cloneTextareas = clone.querySelectorAll('textarea');
        cloneTextareas.forEach((textarea, i) => {
            const original = originalTextareas[i];
            const div = document.createElement('div');
            div.textContent = original?.value || '';
            div.style.whiteSpace = 'pre-wrap';
            div.style.border = '1px dashed #ccc';
            div.style.padding = '4px';
            textarea.replaceWith(div);
        });

        return clone;
    }

    // Update progress bar
    function updateProgress(percent) {
        const progressContainer = document.getElementById("progressContainer");
        const progressBar = document.getElementById("progressBar");
        progressContainer.style.display = "block";
        progressBar.style.width = percent + "%";
        progressBar.textContent = percent + "%";
    }



    document.getElementById("btnPrintPreCheckList").addEventListener("click", async () => {
        const { jsPDF } = window.jspdf;
        const pdf = new jsPDF('l', 'mm', 'a4');

        const pages = [document.getElementById("page1"), document.getElementById("page2")];
        const totalPages = pages.length;

        updateProgress(0);

        for (let i = 0; i < totalPages; i++) {
            const element = pages[i];

            // Attach hidden clone to DOM
            const cleanElement = convertControlsToText(element);
            const hiddenContainer = document.createElement('div');
            hiddenContainer.style.position = 'fixed';
            hiddenContainer.style.left = '-9999px';
            hiddenContainer.appendChild(cleanElement);
            document.body.appendChild(hiddenContainer);

            const canvas = await html2canvas(cleanElement, { scale: 2, useCORS: true });
            document.body.removeChild(hiddenContainer);

            const imgData = canvas.toDataURL("image/png");
            const pageWidth = 297;
            const pageHeight = 210;
            const imgWidth = pageWidth - 20;
            const imgHeight = canvas.height * imgWidth / canvas.width;

            if (i > 0) pdf.addPage();
            pdf.addImage(imgData, 'PNG', 10, 10, imgWidth, imgHeight);

            // Update progress bar (smooth)
            updateProgress(Math.round(((i + 1) / totalPages) * 100));
        }

        pdf.save("Landscape_MultiPage.pdf");

        // Hide progress bar after save
        setTimeout(() => {
            document.getElementById("progressContainer").style.display = "none";
        }, 1000);
    });



    //$('#btnPrintPreCheckList').on('click', function (e) {
    //    // Handle Print Orders button click
    //    e.preventDefault();
    //    var orderDate = $('#OrderDate').val();
    //    if (!orderDate) {
    //        round_warning_noti('Please select an order date.');
    //        return;
    //    }
    //    // Open the PDF in a new tab
    //    window.open(`/ConfirmOrder?handler=PrintReport&selectedOrderDate=${encodeURIComponent(orderDate)}`, '_blank');
    //});
});